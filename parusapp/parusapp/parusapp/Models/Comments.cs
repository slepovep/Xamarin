using System;
using SQLite;

namespace parusapp.Models
{
    [Table("Comments")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int Event_id { get; set; }
        public string Comment_text { get; set; }
        public int InOut_comment { get; set; }
        public string User { get; set; }

    }
}