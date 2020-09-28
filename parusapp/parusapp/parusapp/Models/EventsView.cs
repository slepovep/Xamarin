using System;
using SQLite;

namespace parusapp.Models
{
    [Table("EventsView")]
    public class EventView
    {
        public int Id { get; set; }
        public int Clnevents_id { get; set; }
        public string Event_numb { get; set; }
        public string Event_stat { get; set; }
        public string Reg_date { get; set; }
        public string Change_date { get; set; }
        public string Event_descr { get; set; }
    }
}