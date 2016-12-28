using System;
using System.Collections.Generic;
using System.Xml;

namespace WindowsElnVatView.model
{
    public static class XMLParsers
    {
        public static General ParseElnVatFromXMLDocument(XmlDocument docs)
        {
            var elnVat = new General();
            //XmlDocument doc = new XmlDocument();<issuance xmlns="http://www.w3schools.com" sender="300987980">
            //doc.Load("doc.xml");
            //парсим general
            

            XmlNamespaceManager ns = new XmlNamespaceManager(docs.NameTable);
            ns.AddNamespace("w3s", "http://www.w3schools.com");

            XmlNode doc = docs;
            XmlNode selectNodeGeneral = doc.SelectSingleNode("/w3s:issuance/w3s:general", ns);
            elnVat.number = selectNodeGeneral.SelectSingleNode("w3s:number", ns).InnerText;
            elnVat.dateIssuance = selectNodeGeneral.SelectSingleNode("w3s:dateIssuance", ns).InnerText;
            elnVat.dateTransaction = selectNodeGeneral.SelectSingleNode("w3s:dateTransaction", ns).InnerText;
            elnVat.documentType = selectNodeGeneral.SelectSingleNode("w3s:documentType", ns).InnerText;
            //парсим provider
            XmlNode selectNodeProvider = doc.SelectSingleNode("/w3s:issuance/w3s:provider", ns);
            elnVat.providerStatus = selectNodeProvider.SelectSingleNode("w3s:providerStatus", ns).InnerText;
            elnVat.dependentPersonProvider = tryfalse(selectNodeProvider.SelectSingleNode("w3s:dependentPerson", ns).InnerText);
            elnVat.residentsOfOffshoreProvider = tryfalse(selectNodeProvider.SelectSingleNode("w3s:residentsOfOffshore", ns).InnerText);
            elnVat.specialDealGoodsProvider = tryfalse(selectNodeProvider.SelectSingleNode("w3s:specialDealGoods", ns).InnerText);
            elnVat.bigCompanyProvider = tryfalse(selectNodeProvider.SelectSingleNode("w3s:bigCompany", ns).InnerText);
            elnVat.countryCodeProvider = selectNodeProvider.SelectSingleNode("w3s:countryCode", ns).InnerText;
            elnVat.unpProvider = selectNodeProvider.SelectSingleNode("w3s:unp", ns).InnerText;
            elnVat.nameProvider = selectNodeProvider.SelectSingleNode("w3s:name", ns).InnerText;
            elnVat.addressProvider = selectNodeProvider.SelectSingleNode("w3s:address", ns).InnerText;
            //парсим recipient
            XmlNode selectNodeRecipient = doc.SelectSingleNode("/w3s:issuance/w3s:recipient", ns);
            elnVat.recipientStatus = selectNodeRecipient.SelectSingleNode("w3s:recipientStatus", ns).InnerText;
            elnVat.dependentPersonRecipient = tryfalse(selectNodeRecipient.SelectSingleNode("w3s:dependentPerson", ns).InnerText);
            elnVat.residentsOfOffshoreRecipient = tryfalse(selectNodeRecipient.SelectSingleNode("w3s:residentsOfOffshore", ns).InnerText);
            elnVat.specialDealGoodsRecipient = tryfalse(selectNodeRecipient.SelectSingleNode("w3s:specialDealGoods", ns).InnerText);
            elnVat.bigCompanyRecipient = tryfalse(selectNodeRecipient.SelectSingleNode("w3s:bigCompany", ns).InnerText);
            elnVat.countryCodeRecipient = selectNodeRecipient.SelectSingleNode("w3s:countryCode", ns).InnerText;
            elnVat.unpRecipient = selectNodeRecipient.SelectSingleNode("w3s:unp", ns).InnerText;
            elnVat.nameRecipient = selectNodeRecipient.SelectSingleNode("w3s:name", ns).InnerText;
            elnVat.addressRecipient = selectNodeRecipient.SelectSingleNode("w3s:address", ns).InnerText;
            //парсим contract
            XmlNode selectNodeContract = doc.SelectSingleNode("/w3s:issuance/w3s:deliveryCondition/w3s:contract", ns);
            elnVat.numberDeliveryCondition = selectNodeContract.SelectSingleNode("w3s:number", ns).InnerText;
            elnVat.dateDeliveryCondition = selectNodeContract.SelectSingleNode("w3s:date", ns).InnerText;
            //парсим roster атрибуты
            XmlNode selectNodeRosterAtribute = doc.SelectSingleNode("/w3s:issuance/w3s:roster", ns);
            elnVat.totalCostVatAttrib = selectNodeRosterAtribute.Attributes[0].InnerText;
            elnVat.totalExciseAttrib = selectNodeRosterAtribute.Attributes[1].InnerText;
            elnVat.totalVatAttrib = selectNodeRosterAtribute.Attributes[2].InnerText;
            elnVat.totalCostAttrib = selectNodeRosterAtribute.Attributes[3].InnerText;

            return elnVat;
        }

        public static  List<ModelXMLParsePosition>parseItemRoster(XmlDocument docs)
        {
            var listRoster = new List<ModelXMLParsePosition> { };

            XmlNamespaceManager ns = new XmlNamespaceManager(docs.NameTable);
            ns.AddNamespace("w3s", "http://www.w3schools.com");

            XmlNode doc = docs;
            //парсим roster
            XmlNode selectNodeRosterItem = doc.SelectSingleNode("/w3s:issuance/w3s:roster", ns);
            XmlNodeList rosterItem = selectNodeRosterItem.SelectNodes("w3s:rosterItem", ns);

            foreach (XmlNode node in rosterItem)
            {
                var listsRoster = new ModelXMLParsePosition();
                listsRoster.numberItemRoster = node.SelectSingleNode("w3s:number", ns).InnerText;
                listsRoster.nameRoster = node.SelectSingleNode("w3s:name", ns).InnerText;
                if (node.SelectSingleNode("w3s:count", ns)!= null) { listsRoster.countRoster = node.SelectSingleNode("w3s:count", ns).InnerText; }
                else { listsRoster.countRoster = "0.00"; }
                listsRoster.prisceRoster = node.SelectSingleNode("w3s:price", ns).InnerText;
                listsRoster.costRoster = node.SelectSingleNode("w3s:cost", ns).InnerText;
                listsRoster.summaExciseRoster = node.SelectSingleNode("w3s:summaExcise", ns).InnerText;
                listsRoster.costVatRoster = node.SelectSingleNode("w3s:costVat", ns).InnerText;
                //node.SelectSingleNode("/w3s:issuance/w3s:roster/w3s:rosterItem/w3s:vat", ns);
                listsRoster.rateNdsRoster = node.SelectSingleNode("w3s:vat/w3s:rate", ns).InnerText;
                listsRoster.rateTypeRoster = node.SelectSingleNode("w3s:vat/w3s:rateType", ns).InnerText;
                listsRoster.summaVatRoster = node.SelectSingleNode("w3s:vat/w3s:summaVat", ns).InnerText;
                
            listRoster.Add(listsRoster);
               
            }
            return listRoster;
        }
            

        public static bool tryfalse(string lineXml)
        {
            if (lineXml == "true")
            {
                return true;
            } else {
                return false;
            }
        }
       
    }
}