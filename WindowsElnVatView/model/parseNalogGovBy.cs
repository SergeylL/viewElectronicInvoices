﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsElnVatView.model
{
    class parseNalogGovBy
    {
        public string unpNalogGovBy { get; set; }
        public string nameNalogGovBy { get; set; }
        public string adressNalogGovBy { get; set; }

        public static parseNalogGovBy getXmlFromNalogGovBy(string unp)
        {
            parseNalogGovBy recipient = new parseNalogGovBy();
            string UrlPortal = "http://www.portal.nalog.gov.by/grp/getData?unp="+ unp +"&charset=UTF-8";
            XmlDocument getXml = new XmlDocument();
            try
            {
                getXml.Load(UrlPortal);
                XmlNode urlXml = getXml;
                XmlNode selectGeneralRow = urlXml.SelectSingleNode("/ROWSET/ROW");
                recipient.unpNalogGovBy = selectGeneralRow.SelectSingleNode("VUNP").InnerText;
                recipient.nameNalogGovBy = selectGeneralRow.SelectSingleNode("VNAIMK").InnerText;
                recipient.adressNalogGovBy = selectGeneralRow.SelectSingleNode("VPADRES").InnerText;
            }
            catch (Exception e)
            {
                const string caption = "Внимание!";
                var result = MessageBox.Show(e.Message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Question);
            }
            
            return recipient;
        }

        public parseNalogGovBy()
        {
            unpNalogGovBy = "";
            nameNalogGovBy = "";
            adressNalogGovBy = "";
        }



    }
}
