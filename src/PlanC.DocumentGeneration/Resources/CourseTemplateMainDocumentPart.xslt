<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:v="urn:schemas-microsoft-com:vml"
                xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
                xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml"
                xmlns:o="urn:schemas-microsoft-com:office:office"
                xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
                exclude-result-prefixes="msxsl">

  <xsl:import href="WordprocessingMlHelpers.xslt"/>

  <xsl:output method="xml"
              omit-xml-declaration="yes"
              indent="yes"/>

  <xsl:decimal-format decimal-separator=","
                      grouping-separator=" "/>

  <!--
  Les propriétés par défaut d'une section. Nécéssaire, puisqu'on doit répéter ces infos à chaque nouvelle section.
  Sinon, Word utilise ses propres valeurs par défaut.
  -->
  <xsl:variable name="default-sectPr-child">
    <w:footerReference w:type="default"
                       r:id="rId7"/>
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
  </xsl:variable>

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
            <w:t>
              <xsl:value-of select="/CourseTemplate/EducativeIntent"/>
            </w:t>
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
            <w:t>
              <xsl:value-of select="/CourseTemplate/CourseDescription"/>
            </w:t>
          </w:r>
        </w:p>
        <!--Préalables-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Préalables</w:t>
          </w:r>
        </w:p>
        <xsl:apply-templates select="/CourseTemplate/Prerequisites"/>        
        <!--Compétences-->
        <!--Saut de section page suivante-->
        <w:p>
          <w:pPr>
            <w:sectPr>
              <xsl:copy-of select="$default-sectPr-child"/>
              <w:type w:val="nextPage" />
            </w:sectPr>
          </w:pPr>
        </w:p>
        <!--L'intertitre et le tableau-->
        <xsl:apply-templates select="/CourseTemplate/Skills">
          <xsl:with-param name="ordered-list-id">2</xsl:with-param>
          <xsl:with-param name="unordered-list-id">3</xsl:with-param>
          <xsl:with-param name="sectPr-child"
                          select="$default-sectPr-child"/>
        </xsl:apply-templates>
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
        <xsl:apply-templates select="/CourseTemplate/FinalExam"/>
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
          <xsl:copy-of select="$default-sectPr-child"/>
        </w:sectPr>
      </w:body>
    </w:document>
  </xsl:template>
</xsl:stylesheet>
