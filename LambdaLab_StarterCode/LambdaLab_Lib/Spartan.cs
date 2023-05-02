using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaLab_Lib
{
    public  class Spartan
    {
        [MaxLength(6)]
        public string? SpartanId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int SpartaMark { get; set; }
    }
}
