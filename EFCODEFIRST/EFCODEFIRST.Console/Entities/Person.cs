using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCODEFIRST.Entities
{
    public class Person
    {
        public Person()
        {
            Grades = new HashSet<Grade>();
            Workshops = new HashSet<Workshop>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(200)]
        public string Lastname { get; set; }

        public DateTime? Birthdate { get; set; }

        // 1 op veel relatie
        public ICollection<Grade> Grades { get; set; }

        // veel op veel relatie
        public ICollection<Workshop> Workshops { get; set; }
    }
}
