using DataStructures.Tree.BSTree;

namespace ElectronicHealthCard.Models
{
    public class HospitalCompany : IComparable<HospitalCompany>
    {
        public InsuranceCompany InsuranceCompany { get; set; }
        public BSTree<Patient> ActualPatients { get; set; }
        public BSTree<ListRecords> Records { get; set; }
        public HospitalCompany()
        {
            InsuranceCompany = new InsuranceCompany();
            ActualPatients = new BSTree<Patient>();
        }
        public HospitalCompany(InsuranceCompany insuranceCompany)
        {
            InsuranceCompany = insuranceCompany;
            ActualPatients = new BSTree<Patient>();
            Records = new BSTree<ListRecords>();
        }
        public bool AddActualPatient(Patient patient)
        {
            return ActualPatients.Add(patient);
        }
        public bool AddRecord(Record record)
        {
            var insuranceRecord = new ListRecords(record.Start);
            var findRecord = this.Records.Find(insuranceRecord);
            if (findRecord != null)
            {
                findRecord.Records.Add(record);
            }
            else
            {
                this.Records.Add(insuranceRecord);
                insuranceRecord.Records.Add(record);
            }
            return true;
        }
        public bool DeleteActualPatient(Patient patient)
        {
            return ActualPatients.Delete(patient);
        }
        public int CompareTo(HospitalCompany? other)
        {
            return InsuranceCompany.CompareTo(other.InsuranceCompany);
        }
        public InsuranceInvoice GenerateInvoice(DateTime date)
        {
            var invoice = new InsuranceInvoice(this.InsuranceCompany, date);
            var newDate = new DateTime(date.Year, date.Month, 1);
            var oldDate = date.AddMonths(1);
            while (newDate.Month < oldDate.Month)
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
