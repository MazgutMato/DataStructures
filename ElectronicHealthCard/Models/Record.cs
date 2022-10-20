namespace ElectronicHealthCard.Models
{
    public class Record : IComparable<Record>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Diagnoze { get; set; }
        public Record()
        {
            Start = DateTime.MinValue;
            End = DateTime.MinValue;
            Diagnoze = null;
        }
        public Record(DateTime start, string diagnoze)
        {
            Start = start;
            End = DateTime.MinValue;
            Diagnoze = diagnoze;
        }
        public Record(DateTime start, DateTime end, string diagnoze)
        {
            Start = start;
            End = end;
            Diagnoze = diagnoze;
        }
        public int CompareTo(Record? other)
        {            
            var comStart = this.Start.CompareTo(other.Start);
            var comEnd = this.End.CompareTo(other.End);
            if (comStart != 0)
            {
                return comStart;
            } else
            {
                return comEnd;
            }
        }
    }
}
