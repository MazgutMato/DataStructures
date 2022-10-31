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
    }
}
