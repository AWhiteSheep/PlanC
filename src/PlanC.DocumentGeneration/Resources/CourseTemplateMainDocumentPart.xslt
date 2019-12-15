<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:v="urn:schemas-microsoft-com:vml"
                xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
                xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml"
                xmlns:o="urn:schemas-microsoft-com:office:office"
                exclude-result-prefixes="msxsl">

  <xsl:import href="WordprocessingMlHelpers.xslt"/>

  <xsl:output method="xml"
              omit-xml-declaration="yes"
              indent="yes"/>

  <xsl:decimal-format decimal-separator=","
                      grouping-separator=" "/>
  
  <!--Modèle pour une liste de préalables avec un entête indiquant le type de préalable.-->
  <xsl:template name="prerequisite-paragraph"
                match="Prerequisite">
    <xsl:param name="header-text"/>
    <xsl:param name="prerequisite-type"/>
    <w:p>
      <w:pPr>
        <w:pStyle w:val="Heading2"/>
      </w:pPr>
      <w:r>
        <w:t>
          <xsl:value-of select="$header-text"/>
        </w:t>
      </w:r>
    </w:p>
    <xsl:choose>
      <xsl:when test="/CourseTemplate/Prerequisites/Prerequisite[PrerequisiteType=$prerequisite-type]">
        <xsl:for-each select="/CourseTemplate/Prerequisites/Prerequisite[PrerequisiteType=$prerequisite-type]">
          <w:p>
            <w:pPr>
              <w:pStyle w:val="NoSpacing2"/>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="./CourseTitle"/> (<xsl:value-of select="./CourseId"/>)
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
      </xsl:when>
      <xsl:otherwise>
        <w:p>
          <w:pPr>
            <w:pStyle w:val="NoSpacing2"/>
          </w:pPr>
          <w:r>
            <w:t>Aucun</w:t>
          </w:r>
        </w:p>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--Modèle pour une 'date clée' dans le plan-cadre (p. ex., la date de recommendation d'adoption du département)-->
  <xsl:template name="key-date-paragraph">
    <xsl:param name="header-text"/>
    <xsl:param name="date-element"/>

    <w:p>
      <w:pPr>
        <w:tabs>
          <!--La tabulation pour l'icone-->
          <w:tab w:val="center" w:pos="1701"/>
        </w:tabs>
      </w:pPr>
      <w:r>
        <w:rPr>
          <w:rStyle w:val="InlineLabel"/>
        </w:rPr>
        <w:t>
          <xsl:value-of select="$header-text"/>
        </w:t>
      </w:r>
      <w:r>
        <w:br/>
      </w:r>
      <xsl:choose>
        <xsl:when test="$date-element[@xsi:nil='true']">
          <w:r>
            <w:t>À déterminer</w:t>
            <w:tab/>
          </w:r>
          <xsl:call-template name="red-x-run"/>
        </xsl:when>
        <xsl:otherwise>
          <w:r>
            <w:t>
              <xsl:value-of select="$date-element"/>
            </w:t>
            <w:tab/>
          </w:r>
          <xsl:call-template name="green-checkmark-run"/>
        </xsl:otherwise>
      </xsl:choose>
    </w:p>
  </xsl:template>

  <!--Modèle pour l'ensemble du document-->
  <xsl:template match="/">
    <w:document>
      <w:body>
        <!--Entête avec le titre du cours et son code-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Title"/>
          </w:pPr>
          <w:r>
            <w:t>Plan-cadre</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:pPr>
            <w:tabs>
              <w:tab w:val="right"
                     w:pos="9356"/>
            </w:tabs>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="InlineLabel"/>
            </w:rPr>
            <w:t xml:space="preserve">Titre du cours : </w:t>
          </w:r>
          <w:r>
            <w:t>
              <xsl:value-of select="/CourseTemplate/CourseTitle"/>
            </w:t>
          </w:r>
          <w:r>
            <w:tab/>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="InlineLabel"/>
            </w:rPr>
            <w:t xml:space="preserve">Numéro : </w:t>
          </w:r>
          <w:r>
            <w:t>
              <xsl:value-of select="/CourseTemplate/CourseId"/>
            </w:t>
          </w:r>
        </w:p>
        <!--Le HR-->
        <w:p>
          <w:r>
            <w:pict w14:anchorId="5B6A96CC">
              <v:rect id="_x0000_i1025"
                      style="width:0;height:1.5pt"
                      o:hralign="center"
                      o:hrstd="t"
                      o:hr="t"
                      fillcolor="#a0a0a0"
                      stroked="f"/>
            </w:pict>
          </w:r>
        </w:p>
        <!--Autres champs scalaires-->
        <w:p>
          <w:pPr>
            <w:tabs>
              <w:tab w:val="right"
                     w:pos="9356"/>
            </w:tabs>
          </w:pPr>
          <!--Étiquette pondération-->
          <w:r>
            <w:rPr>
              <w:rStyle w:val="InlineLabel"/>
            </w:rPr>
            <w:t xml:space="preserve">Pondération : </w:t>
          </w:r>
          <!--Valeur Pondération-->
          <w:r>
            <w:t>
              <xsl:apply-templates select="/CourseTemplate/TimeDistribution"/>
            </w:t>
          </w:r>
          <w:r>
            <w:tab/>
          </w:r>
          <!--Étiquette nombre d'unité-->
          <w:r>
            <w:rPr>
              <w:rStyle w:val="InlineLabel"/>
            </w:rPr>
            <w:t xml:space="preserve">Unités : </w:t>
          </w:r>
          <!--Valeur nombre d'unité-->
          <w:r>
            <w:t>
              <xsl:value-of select="/CourseTemplate/UnitsCount"/>
            </w:t>
          </w:r>
        </w:p>
        <!--Intentions pédagogiques-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Intentions pédagogiques</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:r>
            <w:t>
              <xsl:value-of select="/CourseTemplate/PedagogicalIntent"/>
            </w:t>
          </w:r>
        </w:p>
        <!--Intentions éducatives-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Intentions éducatives</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:r>
            <w:t>###</w:t>
          </w:r>
        </w:p>
        <!--Brève description du cours-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Brève description du cours</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:r>
            <w:t>###</w:t>
          </w:r>
        </w:p>
        <!--Préalables...-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Préalables</w:t>
          </w:r>
        </w:p>
        <!--...Corequis-->
        <xsl:call-template name="prerequisite-paragraph">
          <xsl:with-param name="header-text">Corequis</xsl:with-param>
          <xsl:with-param name="prerequisite-type">CoRequisite</xsl:with-param>
        </xsl:call-template>
        <!--...Relatifs-->
        <xsl:call-template name="prerequisite-paragraph">
          <xsl:with-param name="header-text">Relatifs</xsl:with-param>
          <xsl:with-param name="prerequisite-type">Relative</xsl:with-param>
        </xsl:call-template>
        <!--...Absolus-->
        <xsl:call-template name="prerequisite-paragraph">
          <xsl:with-param name="header-text">Absolus</xsl:with-param>
          <xsl:with-param name="prerequisite-type">Absolute</xsl:with-param>
        </xsl:call-template>
        
        <!--Compétences-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Compétences</w:t>
          </w:r>
        </w:p>
        <!--Tableaux des compétences-->
        <xsl:for-each select="/CourseTemplate/Skills/Skill">
          <w:tbl>
            <w:tblPr>
              <w:tblStyle w:val="TableGrid"/>
              <w:tblW w:w="0"
                      w:type="auto"/>
              <w:tblLook w:firstRow="1"
                         w:lastRow="0"
                         w:firstColumn="0"
                         w:lastColumn="0"
                         w:noHBand="0"
                         w:noVBand="1"/>
            </w:tblPr>
            <w:tblGrid>
              <w:gridCol w:w="3116"/>
              <w:gridCol w:w="3117"/>
              <w:gridCol w:w="3117"/>
            </w:tblGrid>
            <!--Ligne 1 avec le code de la compétence-->
            <w:tr>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="9350"
                         w:type="dxa"/>
                  <w:gridSpan w:val="3"/>
                  <w:shd w:val="clear"
                         w:color="auto"
                         w:fill="B4C6E7"
                         w:themeFill="accent1"
                         w:themeFillTint="66"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableSkillCode"/>
                  </w:pPr>
                  <w:r>
                    <w:t>00LM</w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
            <!--Ligne 2-->
            <w:tr>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3116"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader1"/>
                  </w:pPr>
                  <w:r>
                    <w:t>Objectif</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader1"/>
                  </w:pPr>
                  <w:r>
                    <w:t>Standard</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader1"/>
                  </w:pPr>
                  <w:r>
                    <w:t>Précisions sur les contenus</w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
            <!--Ligne 3-->
            <w:tr>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3116"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader2"/>
                  </w:pPr>
                  <w:r>
                    <w:t>Énoncé de la compétence</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader2"/>
                  </w:pPr>
                  <w:r>
                    <w:t>Contexte de réalisation</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader2"/>
                  </w:pPr>
                </w:p>
              </w:tc>
            </w:tr>
            <!--Ligne 4-->
            <w:tr>
              <!--Cellule 1-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3116"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="./Title"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <!--Cellule 2-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <xsl:call-template name="list-section">
                  <xsl:with-param name="data-list-node" select="./AchievementContexts"/>
                  <xsl:with-param name="items-level">0</xsl:with-param>
                  <xsl:with-param name="list-id">1</xsl:with-param>
                </xsl:call-template>
              </w:tc>
              <!--Cellule 3-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <xsl:call-template name="list-section">
                  <xsl:with-param name="data-list-node" select="./ContentPrecisions"/>
                  <xsl:with-param name="items-level">0</xsl:with-param>
                  <!--TODO: This should actually be a separate list-->
                  <xsl:with-param name="list-id">1</xsl:with-param>
                </xsl:call-template>
              </w:tc>
            </w:tr>
            <!--Ligne 5-->
            <w:tr>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3116"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader2"/>
                  </w:pPr>
                  <w:r>
                    <w:t>Éléments de compétence</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader2"/>
                  </w:pPr>
                  <w:r>
                    <w:t>Critère de performance</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="SkillTableHeader2"/>
                  </w:pPr>
                </w:p>
              </w:tc>
            </w:tr>
            <!--Ligne 6-->
            <w:tr>
              <!--Cellule 1-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3116"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="0"/>
                      <w:numId w:val="2"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <!--Cellule 2-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="1"/>
                      <w:numId w:val="2"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="1"/>
                      <w:numId w:val="2"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <!--Cellule 3-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="0"/>
                      <w:numId w:val="3"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
            <!--Ligne 7-->
            <w:tr>
              <!--Cellule 1-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3116"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="0"/>
                      <w:numId w:val="2"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <!--Cellule 2-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="1"/>
                      <w:numId w:val="2"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="1"/>
                      <w:numId w:val="2"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <!--Cellule 3-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3117"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:pStyle w:val="ListParagraph"/>
                    <w:numPr>
                      <w:ilvl w:val="0"/>
                      <w:numId w:val="3"/>
                    </w:numPr>
                  </w:pPr>
                  <w:r>
                    <w:t>###</w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
          </w:tbl>
          <!--Paragraphe vide après chaque tableau-->
          <w:p/>
        </xsl:for-each>
        <!--Évaluation finale-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Évaluation finale</w:t>
          </w:r>
        </w:p>
        <!--Tableau des pondérations-->
        <w:tbl>
          <w:tblPr>
            <w:tblStyle w:val="TableGrid"/>
            <w:tblW w:w="0"
                    w:type="auto"/>
            <w:tblLook w:val="0620"
                       w:firstRow="1"
                       w:lastRow="0"
                       w:firstColumn="0"
                       w:lastColumn="0"
                       w:noHBand="1"
                       w:noVBand="1"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="4315"/>
            <w:gridCol w:w="4315"/>
          </w:tblGrid>
          <!--Ligne 1-->
          <w:tr>
            <!--Cellule 1-->
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="4315"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Critère</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <!--Cellule 2-->
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="4315"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Pondération</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne 2 à totalLignes-1 pour les critères-->
          <xsl:for-each select="/CourseTemplate/FinalExam/Criterias/FinalExamCriteria">
            <w:tr>
              <!--Cellule 1-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="4315"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="./Description"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <!--Cellule 2-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="4315"
                         w:type="dxa"/>
                </w:tcPr>
                <w:p>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="./Weight"/> %
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
          </xsl:for-each>
          <!--Ligne 3-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="8630"
                       w:type="dxa"/>
                <w:gridSpan w:val="2"/>
                <w:shd w:val="clear"
                       w:color="auto"
                       w:fill="E7E6E6"
                       w:themeFill="background2"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:rPr>
                    <w:rStyle w:val="InlineLabel"/>
                  </w:rPr>
                  <w:t xml:space="preserve">Pondération de l’évaluation : </w:t>
                </w:r>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CourseTemplate/FinalExam/Weight"/> %
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
        </w:tbl>
        <!--Les dates clés de recommendation/d'approbation-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Dates clés</w:t>
          </w:r>
        </w:p>
        <xsl:call-template name="key-date-paragraph">
          <xsl:with-param name="header-text">
            Recommandation d’adoption du département
          </xsl:with-param>
          <xsl:with-param name="date-element"
                          select="/CourseTemplate/DepartmentRecommendationDate"/>
        </xsl:call-template>
        <xsl:call-template name="key-date-paragraph">
          <xsl:with-param name="header-text">
            Recommandation du Comité de programme
          </xsl:with-param>
          <xsl:with-param name="date-element"
                          select="/CourseTemplate/CommitteeRecommendationDate"/>
        </xsl:call-template>
        <xsl:call-template name="key-date-paragraph">
          <xsl:with-param name="header-text">
            Approbation par la Direction des études
          </xsl:with-param>
          <xsl:with-param name="date-element"
                          select="/CourseTemplate/BoardApprovalDate"/>
        </xsl:call-template>
        <w:sectPr>
          <w:pgSz w:w="12240"
                  w:h="15840"/>
          <w:pgMar w:top="1440"
                   w:right="1440"
                   w:bottom="1440"
                   w:left="1440"
                   w:header="708"
                   w:footer="708"
                   w:gutter="0"/>
          <w:cols w:space="708"/>
          <w:docGrid w:linePitch="360"/>
        </w:sectPr>
      </w:body>
    </w:document>
  </xsl:template>
</xsl:stylesheet>
