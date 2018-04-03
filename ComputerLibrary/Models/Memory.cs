using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ComputerLibrary.Models
{
    public class Memory
    {
        public Memory()
        {
            this.Computers = new HashSet<Computer>();
        }

        [Key]
        public long MemoryId { get; set; }
        public string Brand { get; set; }
        public int SizeGb { get; set; }
        public string Speed { get; set; }
        public DateTime LastModified { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }

        public Memory(string Brand, int Size, string Speed)
        {
            this.Brand = Brand;
            this.SizeGb = Size;
            this.Speed = Speed;
            this.LastModified = DateTime.Now;

            this.Computers = new HashSet<Computer>();
        }

        public string PrintAllSpecs()
        {
            string AllSpecs = string.Format("Memory: {0}GB {1}",this.SizeGb, this.Speed);
            return AllSpecs;
        }
        public string PrintSizeSpecs()
        {
            string SizeSpecs = string.Format("{0}GB", this.SizeGb);
            return SizeSpecs;
        }
    }
}
