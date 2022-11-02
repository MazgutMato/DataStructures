using DataStructures.Tree.BSTree;
using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class Hospital : IComparable<Hospital>
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name cannot have less than 3 characters and more than 50 characters in length")]
        public string Name { get; set; }
        public BSTree<HospitalCompany> Companies { get; set; }
        public BSTree<PatientNameList> NameList { get; set; }
        public BSTree<ListRecords> StartRecords { get; set; }
        public Hospital()
        {
            Name = null;
            Companies = new BSTree<HospitalCompany>();
            NameList = new BSTree<PatientNameList>();
            StartRecords = new BSTree<ListRecords>();
        }
        public Hospital(string Name)
        {
            this.Name = Name;
            Companies = new BSTree<HospitalCompany>();
            NameList = new BSTree<PatientNameList>();
            StartRecords = new BSTree<ListRecords>();
        }

        public int CompareTo(Hospital? other)
        {
            return Name.CompareTo(other.Name);
        }
        public bool AddActualPatient(Patient patient, Record record)
        {
            var patientCompany = new HospitalCompany(patient.Insurance);
            var findCompany = Companies.Find(patientCompany);
            if (findCompany != null)
            {
                if (findCompany.AddActualPatient(patient) && findCompany.AddRecord(record))
                {
                    patient.ActualRecord = record;                    
                    return true;
                }
                return false;
            }
            else
            {
                if (Companies.Add(patientCompany) && patientCompany.AddActualPatient(patient) &&
                    patientCompany.AddRecord(record))
                {
                    patient.ActualRecord = record;                    
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool DeleteActualPatients(Patient patient)
        {
            var patientCompany = new HospitalCompany(patient.Insurance);
            var findCompany = Companies.Find(patientCompany);
            if (findCompany != null)
            {
                findCompany.ActualPatients.Delete(patient);
                patient.ActualRecord = null;
                return true;
            }
            return false;

        }
        public bool AddPatientName(Hospitalization hospRecord)
        {
            var patientName = new PatientNameList(hospRecord.Patient.FirstName, hospRecord.Patient.LastName);
            var findPatient = NameList.Find(patientName);
            if (findPatient != null)
            {
                findPatient.HospitalizationRecords.Add(hospRecord);
            }else
            {
                NameList.Add(patientName);
                patientName.HospitalizationRecords.Add(hospRecord);
            }
            return true;
        }
        public bool AddRecord(Record record)
        {
            var recordDate = new ListRecords(record.Start);
            var findRecord = StartRecords.Find(recordDate);
            if (findRecord != null)
            {
                findRecord.Records.Add(record);
                return true;
            }
            else
            {
                recordDate.Records.Add(record);
                return StartRecords.Add(recordDate);
            }
        }
        public bool AddInsuranceRecord(Record record)
        {
            var insurance = record.HospitalizationRecord.Patient.Insurance;
            var newCompany = new HospitalCompany(insurance);
            var findCompany = this.Companies.Find(newCompany);
            if (findCompany != null)
            {
                return findCompany.AddRecord(record);
            }
            else
            {

                return this.Companies.Add(newCompany) && newCompany.AddRecord(record);

            }
        }
        public List<Record> FindPatients(DateTime start, DateTime end)
        {
            var result = new List<Record>();
            var recordDates = new List<ListRecords>();
            //Dates in range
            StartRecords.FindRange(new ListRecords(start), new ListRecords(end), recordDates);
            foreach (var recordDate in recordDates)
            {
                result.AddRange(recordDate.Records);
            }
            //Dates before range
            recordDates.Clear();
            StartRecords.FindRange(new ListRecords(DateTime.MinValue), new ListRecords(
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
        public HospitalCompany FindCompany(HospitalCompany company)
        {
            return Companies.Find(company);
        }
        public List<InsuranceInvoice> GenerateInvoices(DateTime date)
        {
            var invoices = new List<InsuranceInvoice>();
            var iterator = this.Companies.createIterator();
            while (iterator.HasNext())
            {
                var companie = iterator.MoveNext();
                invoices.Add(companie.GenerateInvoice(date));
            }
            return invoices;
        }
        public void Optimalize()
        {
            //All records
            this.StartRecords.BalanceTree();
            //NameList
            var iterator = this.NameList.createIterator();
            while (iterator.HasNext())
            {
                var item = iterator.MoveNext();
                item.HospitalizationRecords.BalanceTree();
            }
            this.NameList.BalanceTree();
            //Actual patients
            var iteratorCompanies = this.Companies.createIterator();
            while (iteratorCompanies.HasNext())
            {
                var company = iteratorCompanies.MoveNext();
                company.ActualPatients.BalanceTree();
            }
            this.Companies.BalanceTree();
        }        
    }
}
