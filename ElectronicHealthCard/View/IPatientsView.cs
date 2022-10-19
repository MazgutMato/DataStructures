using ElectronicHealthCard.Controler;
using ElectronicHealthCard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicHealthCard.View
{
    public interface IPatientsView
    {
        void SetController(PatientsController controller);
        void AddPatient(Patient patient);
        void RemovePatient(Patient patient);

        string FirstName { get; set; }
        string LastName { get; set; }
        string PatientID { get; set; }
        DateTime BirthDate { get; set; }
    }
}
