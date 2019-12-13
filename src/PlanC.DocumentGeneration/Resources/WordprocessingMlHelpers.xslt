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

  <!--Modèle pour un simple paragraphe sans texte-->
  <xsl:template name="empty-paragraph">
    <w:p>
      <w:r>
        <w:t/>
      </w:r>
    </w:p>
  </xsl:template>

  <!--Modèle pour une liste d'éléments. S'il n'y a aucun item, affiche le texte "Aucun item"-->
  <xsl:template name="list-section">
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
</xsl:stylesheet>
