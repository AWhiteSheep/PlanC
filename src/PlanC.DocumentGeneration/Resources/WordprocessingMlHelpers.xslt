<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
                xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
                exclude-result-prefixes="msxsl">
  
  <xsl:output method="xml"
              indent="yes"/>

  <!--Modèle pour l'affichage d'une pondération de temps hepdomadaire-->
  <xsl:template match="TimeDistribution">
    <xsl:value-of select="Theory"/>
    <xsl:text>-</xsl:text>
    <xsl:value-of select="Practice"/>
    <xsl:text>-</xsl:text>
    <xsl:value-of select="Homework"/>
  </xsl:template>

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
      <xsl:when test="self::node()/Prerequisite[PrerequisiteType=$prerequisite-type]">
        <xsl:for-each select="self::node()/Prerequisite[PrerequisiteType=$prerequisite-type]">
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

  <xsl:template name="all-prerequisites-paragraph"
                match="Prerequisites">

    <!--...Corequis-->
    <xsl:call-template name="prerequisite-paragraph">
      <xsl:with-param name="header-text">Corequis</xsl:with-param>
      <xsl:with-param name="prerequisite-type">CoRequisite</xsl:with-param>
      <xsl:with-param name="data-list-node"
                      select="self::node()"/>
    </xsl:call-template>
    <!--...Relatifs-->
    <xsl:call-template name="prerequisite-paragraph">
      <xsl:with-param name="header-text">Relatifs</xsl:with-param>
      <xsl:with-param name="prerequisite-type">Relative</xsl:with-param>
      <xsl:with-param name="data-list-node"
                      select="self::node()"/>
    </xsl:call-template>
    <!--...Absolus-->
    <xsl:call-template name="prerequisite-paragraph">
      <xsl:with-param name="header-text">Absolus</xsl:with-param>
      <xsl:with-param name="prerequisite-type">Absolute</xsl:with-param>
      <xsl:with-param name="data-list-node"
                      select="self::node()"/>
    </xsl:call-template>
  </xsl:template>

  <!--Modèle pour un simple paragraphe sans texte-->
  <xsl:template name="empty-paragraph">
    <w:p>
      <w:r>
        <w:t/>
      </w:r>
    </w:p>
  </xsl:template>
  
  <!--
  Modèle pour les tableaux de compétence.
  Remarque : Nécessite deux listes concrètes; une ordonnée pour les éléments de compétence et une autre avec un pour les
  divers autres items non-numérotés.
  -->
  <xsl:template match="Skills">
    <xsl:param name="ordered-list-id"/>
    <xsl:param name="unordered-list-id"/>
    <xsl:param name="footer-id"/>
    
    <xsl:for-each select="./Skill">
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
            <xsl:call-template name="list-paragraph">
              <xsl:with-param name="data-list-node"
                              select="./AchievementContexts"/>
              <xsl:with-param name="items-level">0</xsl:with-param>
              <xsl:with-param name="list-id"
                              select="$unordered-list-id"/>
            </xsl:call-template>
          </w:tc>
          <!--Cellule 3-->
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3117"
                     w:type="dxa"/>
            </w:tcPr>
            <xsl:call-template name="list-paragraph">
              <xsl:with-param name="data-list-node"
                              select="./ContentPrecisions"/>
              <xsl:with-param name="items-level">0</xsl:with-param>
              <xsl:with-param name="list-id"
                              select="$unordered-list-id"/>
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
                <w:t>Critères de performance</w:t>
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
        <!--Ligne 6...-->
        <xsl:for-each select="./SkillElements/SkillElement">
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
              <xsl:call-template name="list-paragraph">
                <xsl:with-param name="data-list-node"
                                select="./Criterias"/>
                <xsl:with-param name="items-level">1</xsl:with-param>
                <xsl:with-param name="list-id">2</xsl:with-param>
              </xsl:call-template>
            </w:tc>
            <!--Cellule 3-->
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3117"
                       w:type="dxa"/>
              </w:tcPr>
              <xsl:call-template name="list-paragraph">
                <xsl:with-param name="data-list-node"
                                select="./ContentPrecisions"/>
                <xsl:with-param name="items-level">0</xsl:with-param>
                <xsl:with-param name="list-id">3</xsl:with-param>
              </xsl:call-template>
            </w:tc>
          </w:tr>
        </xsl:for-each>
      </w:tbl>
      <!--Saut de section "page suivante" après chaque tableau pour redémarrer la numérotation. À noter que cela ne
      fonctionne qu'avec Word 2013 et supérieur. Par ailleurs, il s'agit d'un hack, selon moi, puisque les listes
      restent liées. De plus, un saut de section est "global" au document, donc il pourrait affecter d'autres listes.
      TODO Utiliser XSLT pour la partie Numérotation-->
      <!--
      <w:p>
        <w:pPr>
          <w:sectPr>
            <w:footerReference w:type="default"
                               r:id="{$footer-id}"/>
            <w:type w:val="nextPage" />
          </w:sectPr>
        </w:pPr>
      </w:p>-->
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="FinalExam">
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
      <xsl:for-each select="./Criterias/FinalExamCriteria">
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
  </xsl:template>

  <!--
  <xsl:template name="lines-to-paragraphs">
    <xsl:for-each select="tokenize(., '&#10;&#10;')">
      <w:p>
        <w:r>
          <w:t>
            <xsl:value-of select="."/>
          </w:t>
        </w:r>
      </w:p>
    </xsl:for-each>
  </xsl:template>
  -->

  <!--Modèle pour représenter chaque item d'un tableau sous forme de paragraphe. Solution tempo.-->
  <xsl:template name="array-to-paragraph">
    <xsl:param name="array"/>
    
    <xsl:for-each select="$array/*">
      <w:p>
        <w:r>
          <w:t>
            <xsl:value-of select="."/>
          </w:t>
        </w:r>
      </w:p>
    </xsl:for-each>
  </xsl:template>

  <!--Modèle pour une liste d'éléments. S'il n'y a aucun item, affiche le texte "Aucun item"-->
  <xsl:template name="list-paragraph">
    <xsl:param name="data-list-node"/>
    <xsl:param name="items-level"/>
    <xsl:param name="list-id"/>

    <xsl:variable name="data-items" select="$data-list-node/*"/>

    <xsl:choose>
      <xsl:when test="count($data-items) = 0">
        <w:p>
          <w:r>
            <w:t>Aucun item</w:t>
          </w:r>
        </w:p>
      </xsl:when>
      <xsl:otherwise>
        <xsl:for-each select="$data-items">
          <w:p>
            <w:pPr>
              <w:pStyle w:val="ListParagraph"/>
              <w:numPr>
                <w:ilvl w:val="{$items-level}"/>
                <w:numId w:val="{$list-id}"/>
              </w:numPr>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="."/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

  <!--Modèle pour un Run avec un crochet vert-->
  <xsl:template name="green-checkmark-run">
    <w:r>
      <w:rPr>
        <w:rFonts w:ascii="Segoe UI Symbol" w:hAnsi="Segoe UI Symbol"/>
        <w:color w:val="70AD47"/>
      </w:rPr>
      <w:t>✔</w:t>
    </w:r>
  </xsl:template>

  <!--Modèle pour un Run avec un X rouge-->
  <xsl:template name="red-x-run">
    <w:r>
      <w:rPr>
        <w:rFonts w:ascii="Segoe UI Symbol" w:hAnsi="Segoe UI Symbol"/>
        <w:color w:val="C45911"/>
      </w:rPr>
      <w:t>❌</w:t>
    </w:r>
  </xsl:template>
</xsl:stylesheet>
