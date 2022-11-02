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
        public InsuranceCompany()
        {
            Name = "";
            Code = "";           
        }
        public InsuranceCompany(string name, string code)
        {
            Name = name;
            Code = code;            
        }

        public int CompareTo(InsuranceCompany? other)
        {
            return Code.CompareTo(other.Code);
        }        
    }
}
