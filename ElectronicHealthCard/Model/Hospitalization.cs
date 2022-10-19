using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicHealthCard.Model
{
    public enum TypesOfDiagnoses
    {
        ZAPAL_PLUC,
        INFARKT
    }
    public class Hospitalization
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TypesOfDiagnoses Diagnoses { get; set; }
    }
}
