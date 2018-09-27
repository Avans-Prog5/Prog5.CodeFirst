using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCODEFIRST.Entities
{
    public class Grade
    {
        public int Id { get; set; }

        [Required]
        public string GradeName { get; set; }

        [Required]
        [DisplayName("Grade")]
        public decimal Result { get; set; }

        // 1 op veel met Person ( 2 way navigation)
        public Person Person { get; set; }
        
    }
}
