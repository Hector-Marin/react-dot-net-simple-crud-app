﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiTasksApp.Models
{
    public class Status
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }
}