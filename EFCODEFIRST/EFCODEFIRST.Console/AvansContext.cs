using EFCODEFIRST.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCODEFIRST
{
    public class AvansContext : DbContext
    {
        public AvansContext()
        {

        }

        // Voeg DbSets toe
        public DbSet<Person> People { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
    }
}
