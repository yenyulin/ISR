<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" encoding="utf-8"/>
  <!-- Find the root node called Menus 
       and call MenuListing for its children -->
  <xsl:template match="/Menus">
    <Menu>
      <xsl:call-template name="MenuListing" />
    </Menu>
  </xsl:template>
  
  <!-- Allow for recusive child node processing -->
  <xsl:template name="MenuListing">
    <xsl:apply-templates select="shop_Subject" />
  </xsl:template>
  
  <xsl:template match="shop_Subject">
    <MenuItem>
      <!-- Convert Menu child elements to MenuItem attributes -->
      <xsl:attribute name="Text">
        <xsl:value-of select="NAME"/>
      </xsl:attribute>
      <xsl:attribute name="ToolTip">
        <xsl:value-of select="DESCRIPTION"/>
      </xsl:attribute>
      <xsl:attribute name="NavigateUrl">
        <xsl:text>/</xsl:text>
        <xsl:value-of select="SITE_NAME"/>
        <xsl:text>/pages/subject.aspx?sid=</xsl:text>
        <xsl:value-of select="SUBJECT_ID"/>
      </xsl:attribute>
      
      <!-- Call MenuListing if there are child Menu nodes -->
      <xsl:if test="count(shop_Subject) > 0">
        <xsl:call-template name="MenuListing" />
      </xsl:if>
    </MenuItem>
  </xsl:template>
</xsl:stylesheet>
