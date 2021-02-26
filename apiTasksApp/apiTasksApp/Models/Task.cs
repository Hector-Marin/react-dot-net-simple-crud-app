using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiTasksApp.Models
{
    public class Task
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public byte [] image { get; set; }
        public string color { get; set; }
        public int status_fk { get; set; }
    }
}
