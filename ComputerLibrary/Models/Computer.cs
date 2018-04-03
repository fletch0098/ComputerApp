using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ComputerLibrary.Models
{
    public class Computer
    {
        [Key]
        public long Id { get; set; }
        public string ConfiguracionName { get; set; }
        public string Memory { get; set; }
        public string Processor { get; set; }
        public string HardDrive { get; set; }
        public DateTime LastModified { get; set; }

        public Computer(string ConfiguracionName, string Memory, string Processor, string HardDrive)
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
    }

}
