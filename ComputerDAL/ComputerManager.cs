using System;
using System.Collections.Generic;
using ComputerLibrary.Models;
using System.Linq;

namespace ComputerDAL
{
    public class ComputerManager : IDataRepository<Computer, long>
    {
        ComputerContext ctx;

        public ComputerManager(ComputerContext c)
        {
            ctx = c;
        }

        public Computer Get(long id)
        {
            var computer = ctx.Computers.FirstOrDefault(b => b.Id == id);
            return computer;
        }

        public IEnumerable<Computer> GetAll()
        {
            var computers = ctx.Computers.ToList();
            return computers;
        }

        public long Add(Computer computer)
        {
            computer.LastModified = DateTime.Now;
            ctx.Computers.Add(computer);
            long computerId = ctx.SaveChanges();
            return computerId;
        }

        public long Delete(long id)
        {
            int computerId = 0;
            var computer = ctx.Computers.FirstOrDefault(b => b.Id == id);
            if (computer != null)
            {
                ctx.Computers.Remove(computer);
                computerId = ctx.SaveChanges();
            }
            return computerId;
        }

        public long Update(long id, Computer item)
        {
            long computerId = 0;
            var computer = ctx.Computers.Find(id);
            if (computer != null)
            {
                computer.ConfiguracionName = item.ConfiguracionName;
                computer.HardDrive = item.HardDrive;
                computer.Memory = item.Memory;
                computer.Processor = item.Processor;
                computer.LastModified = DateTime.Now;

                computerId = ctx.SaveChanges();
            }
            return computerId;
        }
    }
}
