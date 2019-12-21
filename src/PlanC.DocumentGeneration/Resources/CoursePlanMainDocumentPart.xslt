<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:wpc="http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas"
                xmlns:cx="http://schemas.microsoft.com/office/drawing/2014/chartex"
                xmlns:cx1="http://schemas.microsoft.com/office/drawing/2015/9/8/chartex"
                xmlns:cx2="http://schemas.microsoft.com/office/drawing/2015/10/21/chartex"
                xmlns:cx3="http://schemas.microsoft.com/office/drawing/2016/5/9/chartex"
                xmlns:cx4="http://schemas.microsoft.com/office/drawing/2016/5/10/chartex"
                xmlns:cx5="http://schemas.microsoft.com/office/drawing/2016/5/11/chartex"
                xmlns:cx6="http://schemas.microsoft.com/office/drawing/2016/5/12/chartex"
                xmlns:cx7="http://schemas.microsoft.com/office/drawing/2016/5/13/chartex"
                xmlns:cx8="http://schemas.microsoft.com/office/drawing/2016/5/14/chartex"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:aink="http://schemas.microsoft.com/office/drawing/2016/ink"
                xmlns:am3d="http://schemas.microsoft.com/office/drawing/2017/model3d"
                xmlns:o="urn:schemas-microsoft-com:office:office"
                xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
                xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math"
                xmlns:v="urn:schemas-microsoft-com:vml"
                xmlns:wp14="http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing"
                xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing"
                xmlns:w10="urn:schemas-microsoft-com:office:word"
                xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
                xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml"
                xmlns:w15="http://schemas.microsoft.com/office/word/2012/wordml"
                xmlns:w16cid="http://schemas.microsoft.com/office/word/2016/wordml/cid"
                xmlns:w16se="http://schemas.microsoft.com/office/word/2015/wordml/symex"
                xmlns:wpg="http://schemas.microsoft.com/office/word/2010/wordprocessingGroup"
                xmlns:wpi="http://schemas.microsoft.com/office/word/2010/wordprocessingInk"
                xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml"
                xmlns:wps="http://schemas.microsoft.com/office/word/2010/wordprocessingShape"
                exclude-result-prefixes="msxsl">
  
  <xsl:import href="WordprocessingMlHelpers.xslt"/>

  <xsl:output method="xml"
              omit-xml-declaration="yes"
              indent="yes"/>
  
  <!--
  Les propriétés par défaut d'une section. Nécéssaire, puisqu'on doit répéter ces infos à chaque nouvelle section.
  Sinon, Word utilise ses propres valeurs par défaut.
  -->
  <xsl:variable name="default-sectPr-child">
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

  <!--Modèle pour l'ensemble du document-->
  <xsl:template match="/">
    <w:document>
      <w:body>
        <!--Début de la page couverture-->
        <!--Le paragraphe avec le logo-->
        <w:p>
          <w:r>
            <w:rPr>
              <w:noProof/>
            </w:rPr>
            <w:drawing>
              <wp:inline distT="0"
                         distB="0"
                         distL="0"
                         distR="0">
                <wp:extent cx="2066925"
                           cy="1160942"/>
                <wp:effectExtent l="0"
                                 t="0"
                                 r="0"
                                 b="1270"/>
                <wp:docPr id="1"
                          name="Picture 1"/>
                <wp:cNvGraphicFramePr>
                  <a:graphicFrameLocks xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"
                                       noChangeAspect="1"/>
                </wp:cNvGraphicFramePr>
                <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                  <a:graphicData uri="http://schemas.openxmlformats.org/drawingml/2006/picture">
                    <pic:pic xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture">
                      <pic:nvPicPr>
                        <pic:cNvPr id="1"
                                   name="003_CO_H_CMYK_Couleur.jpg"/>
                        <pic:cNvPicPr/>
                      </pic:nvPicPr>
                      <pic:blipFill rotWithShape="1">
                        <a:blip r:embed="rId5"
                                cstate="print">
                          <a:extLst>
                            <a:ext>
                              <xsl:attribute name="uri">
                                {28A0092B-C50C-407E-A947-70E740481C1C}
                              </xsl:attribute>
                              <a14:useLocalDpi xmlns:a14="http://schemas.microsoft.com/office/drawing/2010/main"
                                               val="0"/>
                            </a:ext>
                          </a:extLst>
                        </a:blip>
                        <a:srcRect l="13958"
                                   r="1"/>
                        <a:stretch/>
                      </pic:blipFill>
                      <pic:spPr bwMode="auto">
                        <a:xfrm>
                          <a:off x="0"
                                 y="0"/>
                          <a:ext cx="2081097"
                                 cy="1168902"/>
                        </a:xfrm>
                        <a:prstGeom prst="rect">
                          <a:avLst/>
                        </a:prstGeom>
                        <a:ln>
                          <a:noFill/>
                        </a:ln>
                        <a:extLst>
                          <a:ext>
                            <xsl:attribute name="uri">
                              {53640926-AAD7-44D8-BBD7-CCE9431645EC}
                            </xsl:attribute>
                            <a14:shadowObscured xmlns:a14="http://schemas.microsoft.com/office/drawing/2010/main"/>
                          </a:ext>
                        </a:extLst>
                      </pic:spPr>
                    </pic:pic>
                  </a:graphicData>
                </a:graphic>
              </wp:inline>
            </w:drawing>
          </w:r>
        </w:p>
        <!--Le titre statique "Plan de cours"-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Title"/>
          </w:pPr>
          <w:r>
            <w:t>Plan de cours</w:t>
          </w:r>
        </w:p>
        <!--Le HR-->
        <w:p>
          <w:r>
            <w:pict>
              <v:rect id="_x0000_i1025"
                      style="width:468pt;height:3pt"
                      o:hralign="center"
                      o:hrstd="t"
                      o:hrnoshade="t"
                      o:hr="t"
                      fillcolor="#213a8e [3205]"
                      stroked="f"/>
            </w:pict>
          </w:r>
        </w:p>
        <!--Le nom du cours-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Title"/>
          </w:pPr>
          <w:r>
            <w:t>
              <xsl:value-of select="/CoursePlan/CourseTitle"/>
            </w:t>
          </w:r>
        </w:p>
        <!--Le code du cours-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Title"/>
          </w:pPr>
          <w:r>
            <w:t>
              <xsl:value-of select="/CoursePlan/CourseId"/>
            </w:t>
          </w:r>
        </w:p>
        <!--Le paragraphe auquel est ancré le O décoratif en bas à droite de la page-->
        <w:p>
          <w:pPr>
            <w:spacing w:after="960"/>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:noProof/>
            </w:rPr>
            <mc:AlternateContent>
              <mc:Choice Requires="wps">
                <w:drawing>
                  <wp:anchor distT="0"
                             distB="0"
                             distL="114300"
                             distR="114300"
                             simplePos="0"
                             relativeHeight="251659264"
                             behindDoc="1"
                             locked="0"
                             layoutInCell="1"
                             allowOverlap="1">
                    <wp:simplePos x="0"
                                  y="0"/>
                    <wp:positionH relativeFrom="page">
                      <wp:posOffset>4781550</wp:posOffset>
                    </wp:positionH>
                    <wp:positionV relativeFrom="page">
                      <wp:posOffset>7067550</wp:posOffset>
                    </wp:positionV>
                    <wp:extent cx="2995295"
                               cy="2995295"/>
                    <wp:effectExtent l="0"
                                     t="0"
                                     r="0"
                                     b="0"/>
                    <wp:wrapNone/>
                    <wp:docPr id="2"
                              name="Shape 327"/>
                    <wp:cNvGraphicFramePr/>
                    <a:graphic xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main">
                      <a:graphicData uri="http://schemas.microsoft.com/office/word/2010/wordprocessingShape">
                        <wps:wsp>
                          <wps:cNvSpPr/>
                          <wps:spPr>
                            <a:xfrm>
                              <a:off x="0"
                                     y="0"/>
                              <a:ext cx="2995295"
                                     cy="2995295"/>
                            </a:xfrm>
                            <a:custGeom>
                              <a:avLst/>
                              <a:gdLst/>
                              <a:ahLst/>
                              <a:cxnLst/>
                              <a:rect l="0"
                                      t="0"
                                      r="0"
                                      b="0"/>
                              <a:pathLst>
                                <a:path w="1852675"
                                        h="1852678">
                                  <a:moveTo>
                                    <a:pt x="1852675"
                                          y="0"/>
                                  </a:moveTo>
                                  <a:lnTo>
                                    <a:pt x="1852675"
                                          y="824954"/>
                                  </a:lnTo>
                                  <a:lnTo>
                                    <a:pt x="1747596"
                                          y="830259"/>
                                  </a:lnTo>
                                  <a:cubicBezTo>
                                    <a:pt x="1229358"
                                          y="882890"/>
                                    <a:pt x="824954"
                                          y="1320562"/>
                                    <a:pt x="824954"
                                          y="1852676"/>
                                  </a:cubicBezTo>
                                  <a:lnTo>
                                    <a:pt x="824954"
                                          y="1852678"/>
                                  </a:lnTo>
                                  <a:lnTo>
                                    <a:pt x="0"
                                          y="1852678"/>
                                  </a:lnTo>
                                  <a:lnTo>
                                    <a:pt x="0"
                                          y="1852676"/>
                                  </a:lnTo>
                                  <a:cubicBezTo>
                                    <a:pt x="0"
                                          y="861450"/>
                                    <a:pt x="778443"
                                          y="52031"/>
                                    <a:pt x="1757338"
                                          y="2411"/>
                                  </a:cubicBezTo>
                                  <a:lnTo>
                                    <a:pt x="1852675"
                                          y="0"/>
                                  </a:lnTo>
                                  <a:close/>
                                </a:path>
                              </a:pathLst>
                            </a:custGeom>
                            <a:ln w="0"
                                  cap="flat">
                              <a:miter lim="127000"/>
                            </a:ln>
                          </wps:spPr>
                          <wps:style>
                            <a:lnRef idx="0">
                              <a:srgbClr val="000000">
                                <a:alpha val="0"/>
                              </a:srgbClr>
                            </a:lnRef>
                            <a:fillRef idx="1">
                              <a:srgbClr val="15459D"/>
                            </a:fillRef>
                            <a:effectRef idx="0">
                              <a:scrgbClr r="0"
                                          g="0"
                                          b="0"/>
                            </a:effectRef>
                            <a:fontRef idx="none"/>
                          </wps:style>
                          <wps:bodyPr/>
                        </wps:wsp>
                      </a:graphicData>
                    </a:graphic>
                    <wp14:sizeRelH relativeFrom="margin">
                      <wp14:pctWidth>0</wp14:pctWidth>
                    </wp14:sizeRelH>
                    <wp14:sizeRelV relativeFrom="margin">
                      <wp14:pctHeight>0</wp14:pctHeight>
                    </wp14:sizeRelV>
                  </wp:anchor>
                </w:drawing>
              </mc:Choice>
              <mc:Fallback>
                <w:pict>
                  <v:shape id="Shape 327"
                           o:spid="_x0000_s1026"
                           style="position:absolute;margin-left:376.5pt;margin-top:556.5pt;width:235.85pt;height:235.85pt;z-index:-251657216;visibility:visible;mso-wrap-style:square;mso-width-percent:0;mso-height-percent:0;mso-wrap-distance-left:9pt;mso-wrap-distance-top:0;mso-wrap-distance-right:9pt;mso-wrap-distance-bottom:0;mso-position-horizontal:absolute;mso-position-horizontal-relative:page;mso-position-vertical:absolute;mso-position-vertical-relative:page;mso-width-percent:0;mso-height-percent:0;mso-width-relative:margin;mso-height-relative:margin;v-text-anchor:top"
                           coordsize="1852675,1852678"
                           o:gfxdata="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&#xA;8wAAACEGAAAAAA==&#xA;"
                           path="m1852675,r,824954l1747596,830259c1229358,882890,824954,1320562,824954,1852676r,2l,1852678r,-2c,861450,778443,52031,1757338,2411l1852675,xe"
                           fillcolor="#15459d"
                           stroked="f"
                           strokeweight="0">
                    <v:stroke miterlimit="83231f"
                              joinstyle="miter"/>
                    <v:path arrowok="t"
                            textboxrect="0,0,1852675,1852678"/>
                    <w10:wrap anchorx="page"
                              anchory="page"/>
                  </v:shape>
                </w:pict>
              </mc:Fallback>
            </mc:AlternateContent>
          </w:r>
        </w:p>
        <!--Le tableau avec les diverses propriétés du plan de cours-->
        <w:tbl>
          <w:tblPr>
            <w:tblStyle w:val="ListTable7Colorful"/>
            <w:tblW w:w="0"
                    w:type="auto"/>
            <w:jc w:val="center"/>
            <w:tblLook w:val="0680"
                       w:firstRow="0"
                       w:lastRow="0"
                       w:firstColumn="1"
                       w:lastColumn="0"
                       w:noHBand="1"
                       w:noVBand="1"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="2410"/>
            <w:gridCol w:w="3685"/>
          </w:tblGrid>
          <!--Ligne du campus-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Campus</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/Campus"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne du programme-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Programme</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/StudyProgram"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne de la pondération-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Pondération</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:apply-templates select="/CoursePlan/TimeDistribution"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne du groupe-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Groupe</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/Group"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne de la session-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Session</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/Session"/>  
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne du nom de l'enseignant-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Enseignant(e)</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/Teacher/Name"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne numéro de bureau de l'enseignant-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>No de bureau</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/Teacher/Office"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne du numéro de téléphone de l'enseignant-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Téléphone</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/Teacher/PhoneNumber"/>                  
                  </w:t>                
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne de l'adresse courriel de l'enseignant-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Courriel</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>
                    <xsl:value-of select="/CoursePlan/Teacher/EmailAddress"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne des disponibilités de l'enseignant-->
          <w:tr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2410"
                       w:type="dxa"/>
              </w:tcPr>
              <w:p>
                <w:r>
                  <w:t>Disponibilités</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3685"
                       w:type="dxa"/>
              </w:tcPr>
              <!--TODO: Une autre liste où il faut tester la présence d'items. Utiliser un template?-->
              <xsl:choose>
                <xsl:when test="/CoursePlan/Teacher/Availabilities">
                  <xsl:for-each select="/CoursePlan/Teacher/Availabilities/*">
                    <w:p>
                      <w:r>
                        <w:t>
                          <xsl:value-of select="."/>
                        </w:t>
                      </w:r>
                    </w:p>
                  </xsl:for-each>
                </xsl:when>
                <xsl:otherwise>
                  <w:p>
                    <w:r>
                      <w:t>Aucune</w:t>
                    </w:r>
                  </w:p>
                </xsl:otherwise>
              </xsl:choose>
            </w:tc>
          </w:tr>
        </w:tbl>
        <!--Saut de section marquant la fin de la page titre-->
        <w:p>
          <w:pPr>
            <w:sectPr>
              <xsl:copy-of select="$default-sectPr-child"/>
              <w:type w:val="nextPage"/>
            </w:sectPr>
          </w:pPr>
        </w:p>
        <!--Introduction-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Introduction</w:t>
          </w:r>
        </w:p>
        <xsl:call-template name="array-to-paragraph">
          <xsl:with-param name="array"
                          select="/CoursePlan/Introduction"/>
        </xsl:call-template>
        <!--Les préalables-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Préalables</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:r>
            <w:t xml:space="preserve">L’admissibilité à ce cours nécessite que l’étudiant satisfasse à certaines préconditions. On appelle préalable </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="Strong"/>
            </w:rPr>
            <w:t>absolu</w:t>
          </w:r>
          <w:r>
            <w:t xml:space="preserve"> un cours qu’il faut avoir réussi pour être autorisé à s’inscrire au cours pour lequel il est préalable. On appelle préalable </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="Strong"/>
            </w:rPr>
            <w:t>relatif</w:t>
          </w:r>
          <w:r>
            <w:t xml:space="preserve"> un cours qu’il faut avoir suivi (et y avoir obtenu une note de 50% et plus) pour être autorisé à s’inscrire au cours pour lequel il est préalable. Finalement, On appelle cours </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="Strong"/>
            </w:rPr>
            <w:t>corequis</w:t>
          </w:r>
          <w:r>
            <w:t xml:space="preserve"> des cours qui doivent être suivis pour la première fois à la même session.</w:t>
          </w:r>
        </w:p>
        <xsl:apply-templates select="/CoursePlan/Prerequisites"/>
        <!--La pondération-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Pondération</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:r>
            <w:t>(Explication de la pondération)</w:t>
          </w:r>
        </w:p>
        <!--Les intentions pédagogiques-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Intentions pédagogiques</w:t>
          </w:r>
        </w:p>
        <xsl:call-template name="array-to-paragraph">
          <xsl:with-param name="array" select="/CoursePlan/PedagogicalIntents"/>
        </xsl:call-template>
        <!--Les compétences-->
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
        <xsl:apply-templates select="/CoursePlan/Skills">
          <xsl:with-param name="ordered-list-id">2</xsl:with-param>
          <xsl:with-param name="unordered-list-id">3</xsl:with-param>
        <xsl:with-param name="sectPr-child"
                        select="$default-sectPr-child"/>
        </xsl:apply-templates>
        <!--Calendrier des activités-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Calendrier des activités</w:t>
          </w:r>
        </w:p>
        <w:tbl>
          <w:tblPr>
            <w:tblStyle w:val="TableGrid"/>
            <w:tblW w:w="5000"
                    w:type="pct"/>
            <w:tblLook w:firstRow="1"
                       w:lastRow="0"
                       w:firstColumn="1"
                       w:lastColumn="0"
                       w:noHBand="0"
                       w:noVBand="1"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="1361"/>
            <w:gridCol w:w="4984"/>
            <w:gridCol w:w="3005"/>
          </w:tblGrid>
          <!--Ligne 1-->
          <w:tr>
            <!--Cellule 1-->
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1361"
                       w:type="dxa"/>
                <w:shd w:val="clear"
                       w:color="auto"
                       w:fill="213A8E"
                       w:themeFill="accent2"/>
              </w:tcPr>
              <w:p>
                <w:pPr>
                  <w:rPr>
                    <w:rFonts w:asciiTheme="majorHAnsi"
                              w:hAnsiTheme="majorHAnsi"/>
                    <w:color w:val="FFFFFF"
                             w:themeColor="background1"/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:rFonts w:asciiTheme="majorHAnsi"
                              w:hAnsiTheme="majorHAnsi"/>
                    <w:color w:val="FFFFFF"
                             w:themeColor="background1"/>
                  </w:rPr>
                  <w:t>Semaine(s)</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <!--Cellule 2-->
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="0"
                       w:type="auto"/>
                <w:shd w:val="clear"
                       w:color="auto"
                       w:fill="213A8E"
                       w:themeFill="accent2"/>
              </w:tcPr>
              <w:p>
                <w:pPr>
                  <w:rPr>
                    <w:rFonts w:asciiTheme="majorHAnsi"
                              w:hAnsiTheme="majorHAnsi"/>
                    <w:color w:val="FFFFFF"
                             w:themeColor="background1"/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:rFonts w:asciiTheme="majorHAnsi"
                              w:hAnsiTheme="majorHAnsi"/>
                    <w:color w:val="FFFFFF"
                             w:themeColor="background1"/>
                  </w:rPr>
                  <w:t>Contenu</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <!--Cellule 3-->
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3005"
                       w:type="dxa"/>
                <w:shd w:val="clear"
                       w:color="auto"
                       w:fill="213A8E"
                       w:themeFill="accent2"/>
              </w:tcPr>
              <w:p>
                <w:pPr>
                  <w:rPr>
                    <w:rFonts w:asciiTheme="majorHAnsi"
                              w:hAnsiTheme="majorHAnsi"/>
                    <w:color w:val="FFFFFF"
                             w:themeColor="background1"/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:rFonts w:asciiTheme="majorHAnsi"
                              w:hAnsiTheme="majorHAnsi"/>
                    <w:color w:val="FFFFFF"
                             w:themeColor="background1"/>
                  </w:rPr>
                  <w:t>Élément(s) de compétence</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <!--Ligne 2...-->
          <xsl:for-each select="/CoursePlan/ActivityPeriodEntries/ActivityCalendarPeriodEntry">
            <w:tr>
              <!--Cellule 1-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="1361"
                         w:type="dxa"/>
                  <w:vAlign w:val="center"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:jc w:val="center"/>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="./PeriodLabel"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <!--Cellule 2-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="0"
                         w:type="auto"/>
                </w:tcPr>
                <xsl:call-template name="array-to-paragraph">
                  <xsl:with-param name="array" select="./Content"/>
                </xsl:call-template>
              </w:tc>
              <!--Cellule 3-->
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3005"
                         w:type="dxa"/>
                  <w:vAlign w:val="center"/>
                </w:tcPr>
                <w:p>
                  <w:pPr>
                    <w:jc w:val="center"/>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <!--https://stackoverflow.com/a/4942993-->
                      <xsl:for-each select="./SkillElements/*">
                        <xsl:if test="position() != 1">, </xsl:if>
                        <xsl:value-of select="."/>
                      </xsl:for-each>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
          </xsl:for-each>
        </w:tbl>
        <!--Évaluation des apprentissages-->
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Évaluation des apprentissages</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:r>
            <w:t xml:space="preserve">Les étudiant(es) doivent savoir dans quelle mesure ils ont atteint les objectifs du cours. L’enseignant(e) a donc la responsabilité de les informer de leur progrès. Ceci est accompli en utilisant des évaluations </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="Strong"/>
            </w:rPr>
            <w:t>formatives</w:t>
          </w:r>
          <w:r>
            <w:t xml:space="preserve"> et </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="Strong"/>
            </w:rPr>
            <w:t>sommatives</w:t>
          </w:r>
          <w:r>
            <w:t>.</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:r>
            <w:t xml:space="preserve">L'évaluation </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="Strong"/>
            </w:rPr>
            <w:t>formative</w:t>
          </w:r>
          <w:r>
            <w:t xml:space="preserve"> se fait pendant l’apprentissage. Elle indique les forces et les faiblesses. Comme le but est de permettre aux étudiant(es) de s'améliorer, elle ne compte pas pour des points. L'évaluation </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:rStyle w:val="Strong"/>
            </w:rPr>
            <w:t>sommative</w:t>
          </w:r>
          <w:r>
            <w:t xml:space="preserve"> se fait à la fin de l'apprentissage. Elle vérifie si l'étudiant(e) a acquis la compétence et porte un jugement. C'est elle qui fournit la note qui apparaît au bulletin.</w:t>
          </w:r>
        </w:p>
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading2"/>
          </w:pPr>
          <w:r>
            <w:t>Évaluations certificatives</w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="/CoursePlan/Exams/*">
          <w:p>
            <w:pPr>
              <w:pStyle w:val="ListParagraph"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="1"/>
              </w:numPr>
              <w:tabs>
                <w:tab w:val="left"
                       w:pos="4253"
                       w:leader="dot"/>
              </w:tabs>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="./Title"/>
              </w:t>
            </w:r>
            <w:r>
              <w:tab/>
              <w:t>
                <xsl:value-of select="./Weight"/>
                <xsl:text>%</xsl:text>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading3"/>
          </w:pPr>
          <w:r>
            <w:t>Critères de l’évaluation finale</w:t>
          </w:r>
        </w:p>
        <xsl:apply-templates select="/CoursePlan/Exams/FinalExam"/>
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Politiques</w:t>
          </w:r>
        </w:p>
        <xsl:call-template name="array-to-paragraph">
          <xsl:with-param name="array" select="/CoursePlan/Policies"/>
        </xsl:call-template>
        <w:p>
          <w:pPr>
            <w:pStyle w:val="Heading1"/>
          </w:pPr>
          <w:r>
            <w:t>Matériel requis</w:t>
          </w:r>
        </w:p>
        <xsl:call-template name="list-paragraph">
          <xsl:with-param name="data-list-node"
                          select="/CoursePlan/RequiredMaterial"/>
          <xsl:with-param name="items-level">0</xsl:with-param>
          <xsl:with-param name="list-id">55</xsl:with-param><!--TODO-->
        </xsl:call-template>
        <w:sectPr>
          <xsl:copy-of select="$default-sectPr-child"/>
        </w:sectPr>
      </w:body>
    </w:document>
  </xsl:template>
</xsl:stylesheet>
