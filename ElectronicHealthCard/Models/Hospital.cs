using DataStructures.Tree.BSTree;

namespace ElectronicHealthCard.Models
{
    public class Hospital : IComparable<Hospital>
    {
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
