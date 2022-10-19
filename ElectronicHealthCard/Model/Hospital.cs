using DataStructures.Tree.BSTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicHealthCard.Model
{
    public class Hospital : IComparable<Hospital>
    {
        public string Name { get; set; }
        public BSTree<Patient> Patients { get; set; }

        public int CompareTo(Hospital? other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
