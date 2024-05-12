using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company_SDEntities context = new Company_SDEntities();
            Company_SDEntities context2 = new Company_SDEntities();
            Company_SDEntities context3 = new Company_SDEntities();
            Employee emp = (Employee)context.Employees.Where(e => e.SSN == 123).First();
            Employee emp2 = (Employee)context2.Employees.Where(e => e.SSN == 123).First();
            Employee emp3 = (Employee)context3.Employees.Where(e => e.SSN == 123).First();

            emp.Salary += 2000; 
            context.SaveChanges();

            //bool retry = true;
/**/            //while (retry)                    // how to make while to handle exceptions from other contexts!!!!!!!!!!!
            //{

                try
                {
                    emp2.Salary += 3000;
                    context2.SaveChanges();
                  //  retry = false;
                }

                catch (DbUpdateConcurrencyException ex)
                {
                    DbEntityEntry entry = ex.Entries.First();     //dbentityentry has data"its state ..." for obj which is being tracked        // entries >> dbset <entity entry> >> all obj related to err
                    entry.Reload();
                    emp2.Salary += 3000;
                  //  emp3.Salary += 500;
                    
                  //  context3.SaveChanges();
                    context2.SaveChanges();

                }
          //  }
        }

    }
}
