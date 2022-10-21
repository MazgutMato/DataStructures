using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class Generator
    {
        [Required]
        [Range(1,10000)]
        public int HospitalNumber;
        [Required]
        [Range(1, 50000)]
        public int PatientNumber;
        [Required]
        [Range(1, 50000)]
        public int RecordNumber;
        public Generator()
        {
            HospitalNumber = 0;
            PatientNumber = 0;
            RecordNumber = 0;
        }
        public Generator(int hospitalNumber, int patientNumber, int recordNumber)
        {
            HospitalNumber = hospitalNumber;
            PatientNumber = patientNumber;
            RecordNumber = recordNumber;
        }
    }
}
