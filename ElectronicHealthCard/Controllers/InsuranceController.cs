using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;

namespace ElectronicHealthCard.Controllers
{
    public class InsuranceController
    {
        public BSTree<InsuranceCompany> Comanies { get; set; }
        public InsuranceController()
        {
            this.Comanies = new BSTree<InsuranceCompany>();
        }
        public bool AddCompanie(InsuranceCompany company)
        {
            return this.Comanies.Add(company);
        }
        public InsuranceCompany FindCompany(InsuranceCompany insuranceCompany)
        {
            return this.Comanies.Find(insuranceCompany);
        }
        public Iterator<InsuranceCompany> GetCompanies()
        {
            return this.Comanies.createIterator();
        }
        public bool AddCompanies(List<InsuranceCompany> companies)
        {
            return this.Comanies.FillWithMedian(companies);
        }
        public List<InsuranceInvoice> GenerateInvoices(DateTime date)
        {
            var invoices = new List<InsuranceInvoice>();
            var iterator = this.Comanies.createIterator();
            while (iterator.HasNext())
            {
                var companie = iterator.MoveNext();
                invoices.Add(companie.GenerateInvoice(date));
            }
            return invoices;
        }
    }
}
