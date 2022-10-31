namespace ElectronicHealthCard.Models
{
    public class HospitalRecord : IComparable<HospitalRecord>
    {
        public DateTime Date { get; set; }
        public LinkedList<Record> Records { get; set; }
        public HospitalRecord(DateTime date)
        {
            Date = date;
            Records = new LinkedList<Record>();
        }

        public int CompareTo(HospitalRecord? other)
        {
            return Date.CompareTo(other.Date); 
        }
    }
}
