<?xml version="1.0" encoding="utf-8"?> 
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:vs="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"> 
  <xsl:template match="/"> 
    <!-- derived from http://rhysc.blogspot.com/2009/02/mstest-xslt.html  -->
    <html> 
      <body style="font-family:Verdana; font-size:10pt"> 
        <h1>Test Results Summary</h1> 
        <table style="font-family:Verdana; font-size:10pt"> 
          <tr> 
            <td> 
              <b>Run Date/Time</b> 
            </td> 
            <td> 
              <xsl:value-of select="//vs:Times/@creation"/> 
            </td> 
          </tr> 
          <tr> 
            <td> 
              <b>Results </b> 
            </td> 
            <td> 
              <xsl:value-of select="//vs:Deployment/@runDeploymentRoot"/> 
            </td> 
          </tr> 
        </table> 
        <xsl:call-template name="summary" /> 
        <xsl:call-template name="details" /> 
      </body> 
    </html> 
  </xsl:template> 
  <xsl:template name="summary"> 
    <h3>Test Summary</h3> 
    <table style="width:640;border:1px solid black;font-family:Verdana; font-size:10pt"> 
      <tr> 
        <td style="font-weight:bold">Total</td> 
        <td style="font-weight:bold">Failed</td> 
        <td style="font-weight:bold">Passed</td> 
      </tr> 
      <tr> 
        <td > 
          <xsl:value-of select="//vs:ResultSummary/vs:Counters/@total"/> 
        </td> 
        <td style="background-color:pink;"> 
          <xsl:value-of select="//vs:ResultSummary/vs:Counters/@failed"/> 
        </td> 
        <td style="background-color:lightgreen;"> 
          <xsl:value-of select="//vs:ResultSummary/vs:Counters/@passed"/> 
        </td> 
      </tr> 
    </table> 
  </xsl:template> 
  <xsl:template name="details"> 
    <h3>Unit Test Results</h3> 
<table style="width:640;border:1px solid black;font-family:Verdana; font-size:10pt;"> 
      <tr> 
        <td style="font-weight:bold">Test Name</td> 
        <td style="font-weight:bold">Result</td> 
      </tr> 
      <xsl:for-each select="//vs:Results/vs:UnitTestResult"> 
        <tr> 
          <xsl:attribute name="style"> 
            <xsl:choose> 
              <xsl:when test="@outcome = 'Failed'">background-color:pink;</xsl:when> 
<xsl:when test="@outcome = 'Passed'">background-color:lightgreen;</xsl:when> 
              <xsl:otherwise>background-color:yellow;</xsl:otherwise> 
            </xsl:choose> 
          </xsl:attribute> 
          <td> 
            <xsl:value-of select="@testName"/> 
          </td> 
          <td> 
            <xsl:choose> 
              <xsl:when test="@outcome = 'Failed'">FAILED</xsl:when> 
              <xsl:when test="@outcome = 'Passed'">Passed</xsl:when> 
              <xsl:otherwise>Inconclusive</xsl:otherwise> 
            </xsl:choose> 
          </td> 
        </tr> 
      </xsl:for-each> 
    </table> 
  </xsl:template> 
</xsl:stylesheet>