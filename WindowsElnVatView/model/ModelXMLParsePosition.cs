using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsElnVatView.model
{
    public  class ModelXMLParsePosition
    {
        public string nameRoster { get; set; }
        public string numberItemRoster { get; set; }
        public string countRoster { get; set; }
        public string prisceRoster { get; set; }
        public string costRoster { get; set; }
        public string summaExciseRoster { get; set; }
        public string rateNdsRoster { get; set; }
        public string rateTypeRoster { get; set; }
        public string summaVatRoster { get; set; }
        public string costVatRoster { get; set; }

        public ModelXMLParsePosition()
        {
            nameRoster = "";
            numberItemRoster = "";
            countRoster = "";
            prisceRoster = "";
            costRoster = "";
            summaExciseRoster = "";
            rateNdsRoster = "";
            rateTypeRoster = "";
            summaVatRoster = "";
            costVatRoster = "";

        }
    }
    public class ParseDocuments
    {
        public string docType { get; set; }
        public string date { get; set; }
        public string blankCode { get; set; }
        public string serial { get; set; }
        public string number { get; set; }

        public ParseDocuments()
        {
            docType = "";
            date = "";
            blankCode = "";
            serial = "";
            number = "";
        }
    }
 
}
