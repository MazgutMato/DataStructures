using DataStructures.Tree.BSTree;
using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class Hospital : IComparable<Hospital>
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name cannot have less than 3 characters and more than 50 characters in length")]
        public string Name { get; set; }
        public BSTree<Patient> Patients { get; set; }
        public Hospital() {
            this.Name = null;
            this.Patients = new BSTree<Patient>();
        }
        public Hospital(string Name)
        {
            this.Name = Name;
            this.Patients = new BSTree<Patient>();
        }

        public int CompareTo(Hospital? other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
