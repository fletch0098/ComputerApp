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

            var Memories = new Memory[]
            {
            new Memory{  Brand = "Crucial", SizeGb = 8, Speed = "DDR3-1600" , LastModified=DateTime.Now},
            new Memory{  Brand = "Crucial", SizeGb = 8, Speed = "DDR3-1600" , LastModified=DateTime.Now},
            new Memory{  Brand = "Crucial", SizeGb = 8, Speed = "DDR3-1600" , LastModified=DateTime.Now},
            new Memory{  Brand = "Crucial", SizeGb = 8, Speed = "DDR3-1600" , LastModified=DateTime.Now}
            };
            //foreach (Memory m in Memories)
            //{
            //    try
            //    {
            //        context.Memories.Add(m);
            //    }
            //    catch(Exception ex)
            //    {
            //        throw ex;
            //    }
                
            //}

            var computers = new Computer[]
            {
            new Computer{ ConfiguracionName = "The Basic", HardDrive = "512GB HDD", Memory = Memories[0], Processor = "AMD", LastModified=DateTime.Now},
            new Computer{ ConfiguracionName = "The Internet", HardDrive = "128GB SDD", Memory = Memories[1], Processor = "Intel i3", LastModified=DateTime.Now},
            new Computer{ ConfiguracionName = "The Gamer", HardDrive = "1TB HDD", Memory = Memories[2], Processor = "Intel i5", LastModified=DateTime.Now},
            new Computer{ ConfiguracionName = "The Beast", HardDrive = "512GB SDD", Memory = Memories[3], Processor = "Intel i7", LastModified=DateTime.Now}
            };
            foreach (Computer c in computers)
            {
                try
                { 
                context.Computers.Add(c);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            try { 
            context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            log.Info(string.Format("{0} : Seeded Database with {1} Memories", System.Reflection.MethodBase.GetCurrentMethod(), Memories.Count()));
            log.Info(string.Format("{0} : Seeded Database with {1} Computers", System.Reflection.MethodBase.GetCurrentMethod(), computers.Count()));
        }
    }
}
