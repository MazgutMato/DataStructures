namespace ElectronicHealthCard.Models
{
    public class RecordDate : IComparable<RecordDate>
    {
        public DateTime Date { get; set; }
        public LinkedList<Record> Records { get; set; }
        public RecordDate(DateTime date)
        {
            Date = date;
            Records = new LinkedList<Record>();
        }

        public int CompareTo(RecordDate? other)
        {
            return Date.CompareTo(other.Date); 
        }
    }
}
