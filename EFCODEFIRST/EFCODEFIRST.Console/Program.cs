using EFCODEFIRST.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCODEFIRST
{
    class Program
    {
        static void Main(string[] args)
        {
            bool nogEenRondje = true;
            Random random = new Random();
            string[] peopleToChoose = { "bob", "eric", "stijn", "ronald" };

            while (nogEenRondje)
            {
                using (var db = new AvansContext())
                {
                    Console.WriteLine();

                    DoOneToMany(db, peopleToChoose[random.Next(0, 3)]);
                    bool m2m = DoManyToMany(db, peopleToChoose[random.Next(0, 3)]);

                    DisplayResult(db, m2m);
                }
                Console.WriteLine();
                Console.WriteLine("Nog een rondje Y/N?");
                nogEenRondje = Console.ReadKey().KeyChar.ToString().ToLower() == "y";
            }
            Console.ReadLine();
        }

        private static void DisplayResult(AvansContext db, bool m2m)
        {
            foreach (var p in db.People.Include(g => g.Grades).Include(w => w.Workshops))
            {
                Console.WriteLine($"{p.Firstname} {p.Lastname}");
                if (p.Grades.Any())
                {
                    Console.WriteLine($"Grade average: {Math.Round(p.Grades.Average(c => c.Result), 2)}");
                }
                Console.WriteLine("Top 10 Grades:");
                foreach (var g in p.Grades.Take(10))
                {
                    Console.WriteLine($"\t{g.GradeName} {g.Result}");
                }
                foreach (var ws in p.Workshops)
                {
                    Console.WriteLine($"Workshop:\t{ws.WorkshopName}");
                }
                Console.WriteLine();
            }
        }

        static void DoOneToMany(AvansContext db, string forPerson)
        {
            Random random = new Random();
            Grade grade = new Grade
            {
                GradeName = $"Prog {random.Next(1, 4)}",
                Result = random.Next(0, 10)
            };

            var person = db.People.First(x => x.Firstname.ToLower() == forPerson);
            person.Grades.Add(grade);

            db.SaveChanges();
        }

        static bool DoManyToMany(AvansContext db, string forPerson)
        {
            Random random = new Random();
            int id = random.Next(1, 3);

            var person = db.People.Include(x => x.Workshops).First(x => x.Firstname.ToLower() == forPerson);
            var ws = db.Workshops.FirstOrDefault(x => x.Id == id);

            if (ws != null)
            {

                if (!person.Workshops.Any(x => x.Id == ws.Id))
                {
                    person.Workshops.Add(ws);
                    return db.SaveChanges() > 1;
                }
            }
            return false;
        }
    }
}
