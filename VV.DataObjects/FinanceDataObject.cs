namespace VV.DataObjects
{
    public class FinanceDataObject
    {
        public int Id { get; set; }
        public bool IsFinancingAvailable { get; set; }
        public long Payment { get; set; }
        public string PaymentType { get; set; }

        public int NumberOfPayments { get; set; }
        public long DownPayment { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
        public string Odometer { get; set; }
        public string Description { get; set; }
        public string ManufacturerProgram { get; set; }
        public string WarrantyStatus { get; set; }
        public string WarrantyDescription { get; set; }
    }
}

/*<FinancingIsAvailable displayName = "FinancingIsAvailable" > 0 </ FinancingIsAvailable >
< FinancingPayment displayName= "FinancingPayment" />
< FinancingPaymentType displayName = "FinancingPaymentType" />
< FinancingNumberOfPayment displayName= "FinancingNumberOfPayment" />
< FinancingDownPayment displayName = "FinancingDownPayment" />
< FinancingSource displayName= "FinancingSource" />
< FinancingType displayName = "FinancingType" />
< FinancingOdometer displayName= "FinancingOdometer" />
< FinancingDescription displayName = "FinancingDescription" />
< ManufactureProgram displayName= "ManufactureProgram" />
< Warranty displayName = "Warranty" > Not Available</Warranty>
<WarrantyDescription displayName = "WarrantyDescription" />*/