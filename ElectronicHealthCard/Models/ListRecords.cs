namespace ElectronicHealthCard.Models
{
    public class ListRecords : IComparable<ListRecords>
    {
        public DateTime Date { get; set; }
        public List<Record> Records { get; set; }
        public ListRecords()
        {
            Date = DateTime.MinValue;
            Records = new List<Record>();
        }
        public ListRecords(DateTime start)
        {
            Date = start;
            Records = new List<Record>();
        }

        public int CompareTo(ListRecords? other)
        {
            return Date.CompareTo(other.Date);
        }
    }
}
