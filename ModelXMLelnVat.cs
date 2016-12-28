using System;


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
        public int countryCodeProvider { get; set; }
        public string unpProvider { get; set; }
        public string nameProvider { get; set; }
        public string addressProvider { get; set; }
   // }
    
   // public class recipient
   // {
        public string recipientStatus { get; set; }
        public bool dependentPersonRecipient { get; set; }
        public bool residentsOfOffshoreRecipient { get; set; }
        public bool specialDealGoodsRecipient { get; set; }
        public bool bigCompanyRecipient { get; set; }
        public int countryCodeRecipient { get; set; }
        public string unpRecipient { get; set; }
        public string nameRecipient { get; set; }
        public string addressRecipient { get; set; }
  //  }

  //  public class deliveryCondition
   // {
        public string numberDeliveryCondition { get; set; }
        public string dateDeliveryCondition { get; set; }
   // }

    //public class roster
   // {
        public string nameRoster { get; set; }
        public int numberItemRoster { get; set; }  
        public string prisceRoster { get; set; } 
        public string costRoster { get; set; }    
        public string summaExciseRoster { get; set; }
        public int rateNdsRoster { get; set; }
        public string rateTypeRoster { get; set; }
        public string summaVatRoster { get; set; }
        public string costVatRoster { get; set; }


        public General()
        {
            number;
            dateIssuance;
            dateTransaction;
            documentType;
            providerStatus;
            dependentPersonProvider;
            residentsOfOffshoreProvider;
            specialDealGoodsProvider;
            bigCompanyProvider;
            countryCodeProvider;
            unpProvider;
            addressProvider;
            recipientStatus;
            dependentPersonRecipient;
            residentsOfOffshoreRecipient;
            specialDealGoodsRecipient;
            bigCompanyRecipient;
            countryCodeRecipient;
            unpRecipient;
            addressRecipient;
            numberDeliveryCondition;
            dateDeliveryCondition;
            nameRoster;
            numberItemRoster;
            prisceRoster;
            costRoster;
            summaExciseRoster;
            rateNdsRoster;
            rateTypeRoster;
            summaVatRoster;
            costVatRoster;

        }
    }
    


}