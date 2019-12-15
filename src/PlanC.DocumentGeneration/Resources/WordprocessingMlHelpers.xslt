<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
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

  <!--Modèle pour un simple paragraphe sans texte-->
  <xsl:template name="empty-paragraph">
    <w:p>
      <w:r>
        <w:t/>
      </w:r>
    </w:p>
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
