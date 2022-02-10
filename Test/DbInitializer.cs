using ContractInvoice.Data.Contexts;
using ContractInvoice.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ContractInvoice.Test
{
    public static class DbInitializer
    {
        public static void Initialize(ContractInvoiceDbContext context)
        {
            //context.Database.EnsureCreated();

            context.Database.Migrate();

            // Look for any workers.
            if (context.Works.Any())
            {
                return;   // DB has been seeded
            }

            var works = new Work[]
            {
                new Work
                {
                    Id = 1,
                    ProjectId = 731256,
                    CreatedDate = DateTime.Parse("2005-09-01"),
                    CreatedById = "ASDFGGHJ",
                    ModifiedDate = DateTime.Parse("2005-09-02"),
                    ModifiedById = "ModifiedById",
                    HoursWorked = 10,
                    DateWorked = DateTime.Parse("2005-09-03")
                },
                new Work
                {
                    Id = 2,
                    ProjectId = 765456,
                    CreatedDate = DateTime.Parse("2005-07-01"),
                    CreatedById = "qwertyuiio",
                    ModifiedDate = DateTime.Parse("2005-07-02"),
                    ModifiedById = "ModifiedById",
                    HoursWorked = 20,
                    DateWorked = DateTime.Parse("2005-07-03")}
                };

            foreach (Work s in works)
            {
                context.Works.Add(s);
            }

            context.SaveChanges();
        }
    }
}
