using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public static parseNalogGovBy getXmlFromNalogGovBy(General obj)
        {
            parseNalogGovBy recipient = new parseNalogGovBy();
            //string UrlPortal = "http://www.portal.nalog.gov.by/grp/getData?unp="+ unp +"&charset=UTF-8";
            string UrlPortal = "https://lkfl.portal.nalog.gov.by/grp/getData?unp=" + obj.unpRecipient + "&charset=UTF-8&type=xml";
            XmlDocument getXml = new XmlDocument();
                        try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ////HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(UrlPortal);
               // HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                getXml.Load(UrlPortal);
                XmlNode urlXml = getXml;
                XmlNode selectGeneralRow = urlXml.SelectSingleNode("/ROWSET/ROW");
                recipient.unpNalogGovBy = selectGeneralRow.SelectSingleNode("VUNP").InnerText;
                recipient.nameNalogGovBy = selectGeneralRow.SelectSingleNode("VNAIMK").InnerText;
                recipient.adressNalogGovBy = selectGeneralRow.SelectSingleNode("VPADRES").InnerText;
            }
            catch (Exception e)
            {
                recipient.unpNalogGovBy = obj.unpRecipient;
                recipient.nameNalogGovBy = obj.nameRecipient;
                recipient.adressNalogGovBy = obj.addressRecipient;
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
