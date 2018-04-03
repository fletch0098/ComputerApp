using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ComputerLibrary.Models;

namespace ComputerDAL
{
    public static class DbInitializer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Initialize(ComputerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Computers.Any())
            {
                return;   // DB has been seeded
            }

            var computers = new Computer[]
            {
            new Computer{ ConfiguracionName = "The Basic", HardDrive = "512GB HDD", Memory = "4GB DDR3", Processor = "AMD", LastModified=DateTime.Now},
            new Computer{ ConfiguracionName = "The Internet", HardDrive = "128GB SDD", Memory = "4GB DDR3", Processor = "Intel i3", LastModified=DateTime.Now},
            new Computer{ ConfiguracionName = "The Gamer", HardDrive = "1TB HDD", Memory = "8GB DDR4", Processor = "Intel i5", LastModified=DateTime.Now},
            new Computer{ ConfiguracionName = "The Beast", HardDrive = "512GB SDD", Memory = "16GB DDR4", Processor = "Intel i7", LastModified=DateTime.Now}
            };
            foreach (Computer c in computers)
            {
                context.Computers.Add(c);
            }
            context.SaveChanges();

            log.Info(string.Format("{0} : Seeded Database with {1} Computers", System.Reflection.MethodBase.GetCurrentMethod(), computers.Count()));
        }
    }
}
