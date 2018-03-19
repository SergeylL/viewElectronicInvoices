using System;
using System.Collections.Generic;

namespace WindowsElnVatView.model {
    public class General
    {
        public string number { get; set; }
        public string dateIssuance { get; set; }
        public string dateTransaction { get; set; }
        public string documentType { get; set; }
        //  }

        //  public class provider
        // {
        public string providerStatus { get; set; }
        public bool dependentPersonProvider { get; set; }
        public bool residentsOfOffshoreProvider { get; set; }
        public bool specialDealGoodsProvider { get; set; }
        public bool bigCompanyProvider { get; set; }
        public string countryCodeProvider { get; set; }
        public string unpProvider { get; set; }
        public string nameProvider { get; set; }
        public string addressProvider { get; set; }

        // public class recipient

        public string recipientStatus { get; set; }
        public bool dependentPersonRecipient { get; set; }
        public bool residentsOfOffshoreRecipient { get; set; }
        public bool specialDealGoodsRecipient { get; set; }
        public bool bigCompanyRecipient { get; set; }
        public string countryCodeRecipient { get; set; }
        public string unpRecipient { get; set; }
        public string nameRecipient { get; set; }
        public string addressRecipient { get; set; }

        //  public class deliveryCondition
 
        public string numberDeliveryCondition { get; set; }
        public string dateDeliveryCondition { get; set; }

        //roster Атрибуты
        public string totalCostVatAttrib { get; set; }
        public string totalExciseAttrib { get; set; }
        public string totalVatAttrib { get; set; }
        public string totalCostAttrib { get; set; }


        //<roster totalCostVat="1077.53" totalExcise="0.00" totalVat="179.59" totalCost="897.94">
        public General()
        {
            number = "";
            dateIssuance = "";
            dateTransaction = "";
            documentType = "";

            providerStatus = "";
            dependentPersonProvider = false;
            residentsOfOffshoreProvider = false;
            specialDealGoodsProvider = false;
            bigCompanyProvider = false;
            countryCodeProvider = "";
            unpProvider = "";
            nameProvider = "";
            addressProvider = "";


            recipientStatus = "";
            dependentPersonRecipient = false;
            residentsOfOffshoreRecipient = false;
            specialDealGoodsRecipient = false;
            bigCompanyRecipient = false;
            countryCodeRecipient = "";
            unpRecipient = "";
            nameRecipient = "";
            addressRecipient = "";

            numberDeliveryCondition = "";
            dateDeliveryCondition = "";

            totalCostVatAttrib = "";
            totalExciseAttrib = "";
            totalVatAttrib = "";
            totalCostAttrib = "";

            //documentDocTypeCode = "";
            //documentDocTypeValue = "";
            //documentDate = "";
            //documentNumber = "";
        }
    }

   

   

}