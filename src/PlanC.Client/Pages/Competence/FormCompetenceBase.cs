using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.Client.Pages.Competence
{
    public class FormCompetenceBase : ComponentBase
    {
        [Inject]
        protected PCU001Context context { get; set; }

        // paramètre de l'url
        [Parameter]
        public int departementId { get; set; }
        [Parameter]
        public int CurrentStep { get; set; } = 1;
        [Parameter]
        public string competenceId { get; set; }

        // si la compétence à déjà été créé certaine étape peuvent être sauté comme certaine vérification
        public bool isEditing = false;

        // programme pour lequel nous formaton la nouvelle compétence
        public Departements departement;

        // form context
        public IReadOnlyDictionary<string, object> inputCompetenceAttributes = new Dictionary<string, object>();
        public EditContext CompetenceForm;
        public EditContext EditConContext;

        // discipline disponible pour le context doit être initialisé pour le dropdown
        public List<Departements> departements;

        // les valeurs devant être initialisés pour créer un nouvelle compétence
        public Competences skill = new Competences();
        public List<CompetenceContextes> contextRealisationsList;
        public List<CompetenceContextes> contextRealisationsCache;
        public List<ElementsCompetence> skElements;

        public string StatusMessage;
        public string infoMessage;
        public string contextValidationMessage;

        // ajoute un nouveau context pour la compétence demandé
        public async void SettingContext()
        {
            // indexage de la liste contenant les contextes de la compétence donnée
            contextRealisationsList = context.CompetenceContextes
                .Where(e=> skill.CompetenceId == e.CompetenceId && e.DepartementId == skill.DisciplineId)
                .ToList();
            Console.WriteLine($"SQL return code: {await context.SaveChangesAsync()}");

            // check if only editing, sinon nous créons un champ vide pour la nouvelle compétence
            if (!contextRealisationsList.Any())
            {
                AjouterContext();
            }

            // rendu au step 2 de rentrer tous les contextes allant avec la compétence donnée
            CurrentStep = 2;
            StateHasChanged();
        }

        // ajoute un context pour la compétence donnée
        public async void AjouterContext()
        {
            if (contextRealisationsList.Any(e => string.IsNullOrEmpty(e.Text)))
            {
                contextValidationMessage = "SVP, remplir tous les contextes de réalisation avant d'ajouter un suivant.";
                StateHasChanged();
            }
            else
            {
                contextValidationMessage = "";

                skill.CompetenceContextes.Add(new CompetenceContextes() { Text = "" });
                Console.WriteLine($"SQL return code: {await context.SaveChangesAsync()}");

                contextRealisationsList = skill.CompetenceContextes
                    .Where(e => skill.CompetenceId == e.CompetenceId && e.DepartementId == skill.DisciplineId)
                    .ToList();
                StateHasChanged();
            }
        }
        public async void HandleValidContext()
        {
            // validation si la liste n'est pas vide?. certaines compétences peuvent ne pas comporter de context
            contextRealisationsList.RemoveAll(e => string.IsNullOrEmpty(e.Text));
            Console.WriteLine($"SQL return code on context saving: {await context.SaveChangesAsync()}");
            CurrentStep = 3;
            StateHasChanged();
        }
    }
}
