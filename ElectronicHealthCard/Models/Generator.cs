using ElectronicHealthCard.Controllers;
using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class Generator
    {
        [Required]
        public int Hospital;
        [Required]
        public int Patient;
        [Required]
        public int MinActivePatient;
        [Required]
        public int MaxActivePatient;
        [Required]
        public int MinEndedRecord;
        [Required]
        public int MaxEndedRecord;
        public Generator()
        {
            Hospital = 1;
            Patient = 1;
            MinActivePatient = 1;
            MaxActivePatient = 1;
            MinEndedRecord = 1;
            MaxEndedRecord = 1;
        }
    }
}
