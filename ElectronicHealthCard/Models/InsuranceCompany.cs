using DataStructures.Tree.BSTree;
using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class InsuranceCompany : IComparable<InsuranceCompany>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public BSTree<ListRecords> Records { get; set; }
        public InsuranceCompany()
        {
            Name = "";
            Code = "";
            Records = new BSTree<ListRecords>();
        }
        public InsuranceCompany(string name, string code)
        {
            Name = name;
            Code = code;
            Records = new BSTree<ListRecords>();
        }

        public int CompareTo(InsuranceCompany? other)
        {
            return Code.CompareTo(other.Code);
        }
        public bool AddRecord(Record record)
        {
            var insuranceRecord = new ListRecords(record.Start);
            var findRecord = this.Records.Find(insuranceRecord);
            if(findRecord != null)
            {
                findRecord.Records.Add(record);
            } else
            {
                this.Records.Add(insuranceRecord);
                insuranceRecord.Records.Add(record);
            }
            return true;
        }
        public InsuranceInvoice GenerateInvoice(DateTime date)
        {            
            var invoice = new InsuranceInvoice(this, date);
            var newDate = new DateTime(date.Year, date.Month, 1);
            var oldDate = date.AddMonths(1);
            while(newDate.Month < oldDate.Month)
            {
                var listRecord = new ListRecords(newDate);
                listRecord.Records.AddRange(this.FindRecords(newDate, newDate));
                invoice.Records.Add(listRecord);
                invoice.Days += listRecord.Records.Count;
                newDate = newDate.AddDays(1);
            }
            return invoice;
        }
        public List<Record> FindRecords(DateTime start, DateTime end)
        {
            var result = new List<Record>();
            var recordDates = new List<ListRecords>();
            //Dates in range
            this.Records.FindRange(new ListRecords(start), new ListRecords(end), recordDates);
            foreach (var recordDate in recordDates)
            {
                result.AddRange(recordDate.Records);                
            }
            //Dates before range
            recordDates.Clear();
            this.Records.FindRange(new ListRecords(DateTime.MinValue), new ListRecords(
                start.AddDays(-1)), recordDates);
            foreach (var recordDate in recordDates)
            {
                foreach (var record in recordDate.Records)
                {
                    if (record.End == DateTime.MinValue || record.End >= start)
                    {
                        result.Add(record);
                    }
                }
            }
            return result;
        }
    }
}
