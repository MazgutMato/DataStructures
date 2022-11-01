namespace ElectronicHealthCard.Models
{
    public class InsuranceInvoice
    {
        public InsuranceCompany Company { get; set; }
        public DateTime Date { get; set; }
        public int Days { get; set; }
        public List<ListRecords> Records { get; set; }
        public InsuranceInvoice(InsuranceCompany company, DateTime date)
        {
            Company = company;
            Date = date;
            Days = 0;
            Records = new List<ListRecords>();
        }       
    }
}
