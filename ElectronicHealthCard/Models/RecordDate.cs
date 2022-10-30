namespace ElectronicHealthCard.Models
{
    public class RecordDate : IComparable<RecordDate>
    {
        public DateTime Date { get; set; }
        public LinkedList<RecordDate> Records { get; set; }
        public int CompareTo(RecordDate? other)
        {
            return Date.CompareTo(other.Date); 
        }
    }
}
