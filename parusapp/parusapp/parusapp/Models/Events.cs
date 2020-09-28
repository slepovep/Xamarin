using System;
using SQLite;

namespace parusapp.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int Clnevents_id { get; set; }
        public string Event_numb { get; set; }
        public string Event_stat { get; set; }
        public DateTime? Reg_date { get; set; }
        public DateTime? Change_date { get; set; }
        public string Event_descr { get; set; }
    }
}