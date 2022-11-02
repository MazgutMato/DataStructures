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
        public int GetCount()
        {
            return this.Comanies.Count;
        }
        public bool AddCompanies(List<InsuranceCompany> companies)
        {
            return this.Comanies.FillWithMedian(companies);
        }
        public void Optimalize()
        {
            this.Comanies.BalanceTree();
        }
    }
}
