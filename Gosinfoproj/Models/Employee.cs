using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gosinfoproj.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
