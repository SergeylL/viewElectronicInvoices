using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsElnVatView.model
{
    class generateNewXMLfile
    
    {
        public static string boolToString(bool paramtr) {
            string newParamtr = Convert.ToString(paramtr);
            newParamtr = newParamtr.ToLower();
            return newParamtr;
         }

        public static void createNewFileXML(General dateFromForm, string file, List<ModelXMLParsePosition>itemRoster)
        {
            General dateForm = dateFromForm;
            List<ModelXMLParsePosition> itemRosterXMl = itemRoster;
            string itemXML = "";
            //XmlTextWriter writeXmlFile = new XmlTextWriter("e:\\Winners.xml", Encoding.UTF8);
            //writeXmlFile.WriteStartDocument();
            // writeXmlFile.WriteStartElement("issuance");
            //writeXmlFile.WriteEndElement();
            // writeXmlFile.Close();
            foreach (var item in itemRosterXMl)
            {
                 string itemRost = " <rosterItem> " +
                 "<number>"+ item.numberItemRoster +"</number>" +
                 "<name>"+ item.nameRoster +"</name>" +
                 "<count>" + item.countRoster + "</count>" +
                "<price>" + item.prisceRoster +"</price>" +
                "<cost>"+ item.costRoster +"</cost>" +
                "<summaExcise>"+ item.summaExciseRoster +"</summaExcise>" +
                "<vat>"+
                    "<rate>" + item.rateNdsRoster +"</rate>" +
                    "<rateType>" + item.rateTypeRoster +"</rateType>" +
                    "<summaVat>" + item.summaVatRoster +"</summaVat>" +
                "</vat>" +
                "<costVat>" + item.costVatRoster + "</costVat>" +
                "</rosterItem>";
                itemXML = itemXML + itemRost;

            }
            string xmlShema = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<issuance xmlns=\"http://www.w3schools.com\" sender=\""+ dateFromForm.unpProvider +"\"> " +
   "<general> " +
        "<number>"+ dateFromForm.number +"</number>" +
        "<dateIssuance>"+ dateFromForm.dateIssuance +"</dateIssuance>" +
        "<dateTransaction>"+ dateFromForm.dateTransaction +"</dateTransaction>" +
        "<documentType>"+ dateFromForm.documentType +"</documentType>" +
    "</general>" +
    "<provider>" +
        "<providerStatus>"+ dateFromForm.providerStatus +"</providerStatus>" +
        "<dependentPerson>"+ boolToString(dateFromForm.dependentPersonProvider) +"</dependentPerson>" +
        "<residentsOfOffshore>"+ boolToString(dateFromForm.residentsOfOffshoreProvider) +"</residentsOfOffshore>" +
        "<specialDealGoods>"+ boolToString(dateFromForm.specialDealGoodsProvider) +"</specialDealGoods>" +
        "<bigCompany>"+ boolToString(dateFromForm.bigCompanyProvider) +"</bigCompany>" +
        "<countryCode>"+ dateFromForm.countryCodeProvider +"</countryCode>" +
        "<unp>"+ dateFromForm.unpProvider +"</unp>" +
        "<name>"+ dateFromForm.nameProvider +"</name>" +
          "<address>"+ dateFromForm.addressProvider +"</address>" +
          "</provider>" +
          "<recipient>" +
              "<recipientStatus>"+ dateFromForm.recipientStatus +"</recipientStatus>" +
              "<dependentPerson>"+ boolToString(dateFromForm.dependentPersonRecipient) +"</dependentPerson>" +
              "<residentsOfOffshore>"+ boolToString(dateFromForm.residentsOfOffshoreRecipient) +"</residentsOfOffshore>" +
              "<specialDealGoods>"+ boolToString(dateFromForm.specialDealGoodsRecipient) +"</specialDealGoods>" +
              "<bigCompany>"+ boolToString(dateFromForm.bigCompanyRecipient) +"</bigCompany>" +
              "<countryCode>"+ dateFromForm.countryCodeRecipient +"</countryCode>" +
              "<unp>"+ dateFromForm.unpRecipient +"</unp>" +
              "<name>"+ dateFromForm.nameRecipient +"</name>" +
              "<address>"+ dateFromForm.addressRecipient +"</address>" +
         "</recipient>" +
         "<senderReceiver>" +
              "<consignors/>" +
              "<consignees/>" +
         "</senderReceiver>" +
         "<deliveryCondition>" +
              "<contract>" +
                    "<number>"+ dateFromForm.numberDeliveryCondition +"</number>" +
                    "<date>"+ dateFromForm.dateDeliveryCondition +"</date>" +
              "</contract>" +
         "</deliveryCondition>" +
              "<roster totalCostVat=\""+ dateFromForm.totalCostVatAttrib + "\" totalExcise=\""+ dateFromForm.totalExciseAttrib + "\" totalVat=\""+ dateFromForm.totalVatAttrib + "\" totalCost=\""+ dateFromForm.totalCostAttrib +"\">" +
                 itemXML +
             "</roster>" +
       "</issuance>";
            

            XmlDocument docXml = new XmlDocument();
            //docXml.Load("e:\\Winners.xml");
            docXml.LoadXml(xmlShema);
            //Создаем XML
            // XmlNode element = docXml.CreateElement("issuance");
            //   docXml.DocumentElement.AppendChild(element);

            // XmlAttribute attributeXMNLS = docXml.CreateAttribute("xmlns");
            //attributeXMNLS.Value = "http://www.w3schools.com";
            // docXml.Attributes.Append(attributeXMNLS);

            // XmlAttribute attributeSender = docXml.CreateAttribute("sender");
            // attributeSender.Value = dateForm.unpProvider;
            // docXml.Attributes.Append(attributeSender);

            // String s = docXml.InnerXml;
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            using (XmlWriter w = XmlWriter.Create(file, settings))
            {
                docXml.Save(w);
            }

            
        }
        
        
    }
}
