using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerLibrary.Models
{
    public class Computer
    {
        
        public long ComputerId { get; set; }
        public string ConfiguracionName { get; set; }
        public long MemoryId { get; set; }
        public string Processor { get; set; }
        public string HardDrive { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Memory Memory { get; set; }

        public Computer(string ConfiguracionName, int Memory, string Processor, string HardDrive)
        {
            this.ConfiguracionName = ConfiguracionName;
            this.HardDrive = HardDrive;
            this.LastModified = DateTime.Now;
            this.MemoryId = Memory;
            this.Processor = Processor;
        }

        public Computer(string ConfiguracionName, Memory Memory, string Processor, string HardDrive)
        {
            this.ConfiguracionName = ConfiguracionName;
            this.HardDrive = HardDrive;
            this.LastModified = DateTime.Now;
            this.Memory = Memory;
            this.Processor = Processor;
        }

        public Computer()
        {

        }

        public string PrintAllSpecs()
        {
            string AllSpecs = string.Format("{0}: {1}", this.ConfiguracionName, this.Memory.PrintAllSpecs());
            return AllSpecs;
        }
    }

}
