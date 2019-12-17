using Microsoft.JSInterop;
using Syncfusion.EJ;
using Syncfusion.EJ.Export;
using Syncfusion.Compression;
using Syncfusion.DocIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.DocIO.DLS;
using System.IO;
using PlanC.EntityDataModel;
using PlanC.DocumentGeneration.CourseTemplate;
using Microsoft.EntityFrameworkCore;
using PlanC.DocumentGeneration.Common;

namespace PlanC.Client.Data
{
    public static class FileUtil
    {
        /// <summary>
        /// File upload avec js runtime
        /// </summary>
        /// <param name="js"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));

        // return une demande invke avec jsRuntime pour téléchargé du côté client

        public static WordDocument GetDocument(string htmlText)
        {
            // renvoit du word qui était en fait du html
            WordDocument document = null;
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.Default);
            htmlText = htmlText.Replace("\"", "'");
            XmlConversion XmlText = new XmlConversion(htmlText);
            XhtmlConversion XhtmlText = new XhtmlConversion(XmlText);
            writer.Write(XhtmlText.ToString());
            writer.Flush();
            stream.Position = 0;
            document = new WordDocument(stream, FormatType.Html, XHTMLValidationType.None);
            return document;
        }

        public static byte[] FromTemplate(PlanC.EntityDataModel.PlansCadres plansCadre, PCU001Context context) 
        {
            List<PlanCadreCompetenceElements> tempTemplateElements = null;
            if (plansCadre != null)
                tempTemplateElements = context.PlanCadreCompetenceElements.Include(e => e.ElementCompetence)
                    .ThenInclude(d => d.IdentityKeyCompetencesNavigation)
                    .Include(v => v.PlansCadres)
                    .Where(t => t.CoursId.Trim() == plansCadre.CoursId.Trim()).ToList();

            if (tempTemplateElements == null) 
            {
                Console.WriteLine($"Didn't not find any connection to competence elements {plansCadre.CoursId}");
                return null;            
            }

            // First sKILL has competence
            System.Collections.ObjectModel.Collection<Skill> Skills = new System.Collections.ObjectModel.Collection<Skill>();
            // tous les compétences reliés avec le plancadre
            List<Competences> competences = new List<Competences>();

            /// FAIRE LA SKILL LISTE
            ///
            // cycle sur les critere element competence
            foreach (var elementsCompetenceTemplate in tempTemplateElements)
            {
                Competences comp = elementsCompetenceTemplate.ElementCompetence.IdentityKeyCompetencesNavigation;
                // composant d'une compétence
                if (!competences.Contains(comp))
                {
                    competences.Add(comp);
                    Skills.Add(new Skill() { Title = competences.Last().Enonce });
                }

                // trouve le skill et ajoute à celui ci le skill element trouvé
                var _skill = Skills.First(e => e.Title == comp.Enonce);

                if (_skill == null)
                {
                    Console.WriteLine($"Didn't not find {comp.Enonce}");
                }
                else
                {
                    // ajoute au skill trouvé l'élément dans la compétence relié dans laquelle nous nous trouvons
                    _skill.SkillElements.Add(new SkillElement()
                    {
                        Title = elementsCompetenceTemplate.LongDescription,
                        Criterias = new System.Collections.ObjectModel.Collection<string>(elementsCompetenceTemplate.ElementCompetence.GetCritereListString)
                    });

                    // acquired all context has string
                    _skill.AchievementContexts = new System.Collections.ObjectModel.Collection<string>(comp.GetContextListString);
                }
            }

            CourseTemplate template = new CourseTemplate()
            {
                CourseId = plansCadre.CoursId,
                CourseDescription = plansCadre.Description,
                CourseTitle = plansCadre.DenominationCours,
                EducativeIntent = plansCadre.IntentionEducative,
                PedagogicalIntent = plansCadre.IntentionPedagogique,
                TimeDistribution = new TimeDistribution(plansCadre.TheoryHoursAccessor, plansCadre.PracticeHoursAccessor, plansCadre.HomeHoursAccessor),
                UnitsCount = plansCadre.UnitsAccessor,
                Skills = Skills,
            };

            using (var stream = new MemoryStream())
            {
                using (var document = PlanC.DocumentGeneration.CourseTemplate.DocumentFactory.Create(stream))
                {
                    var editor = new DocumentEditor(document);
                    editor.Model = template;
                    editor.ApplyChanges();
                }
                // stream ready envoit un nouveau document
                return stream.ToArray();
            }
        }
    }
}
