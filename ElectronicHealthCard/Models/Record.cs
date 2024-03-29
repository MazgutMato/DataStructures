﻿using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class Record : IComparable<Record>
    {
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [Required]
        public string Diagnoze { get; set; }
        public Hospitalization HospitalizationRecord { get; set; }
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
            return this.Start.CompareTo(other.Start);
        }
    }
}
