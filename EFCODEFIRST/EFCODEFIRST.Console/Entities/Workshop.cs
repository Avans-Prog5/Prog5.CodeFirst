using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCODEFIRST.Entities
{
    public class Workshop
    {
        public Workshop()
        {
            People = new HashSet<Person>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string WorkshopName { get; set; }
        public bool Active { get; set; }

        // Veel op Veel relatie
        public ICollection<Person> People { get; set; }

    }
}
