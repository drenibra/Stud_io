using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stud_io.Authentication.Models
{
    public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}