using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTasksApp.Models
{
    public class TaskFile
    {
        public IFormFile file { get; set; }
        public Task task { get; set; }
    }
}
