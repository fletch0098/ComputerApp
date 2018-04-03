using System;
using System.Collections.Generic;
using ComputerLibrary.Models;
using System.Linq;

namespace ComputerDAL
{
    public class MemoryManager : IDataRepository<Memory, long>
    {
        ComputerContext ctx;

        public MemoryManager(ComputerContext c)
        {
            ctx = c;
        }

        public Memory Get(long id)
        {
            var query = ctx.Memories.FirstOrDefault(b => b.MemoryId == id);
            return query;
        }

        public IEnumerable<Memory> GetAll()
        {
            var query = ctx.Memories.ToList();
            return query;
        }

        public long Add(Memory entity)
        {
            entity.LastModified = DateTime.Now;
            ctx.Memories.Add(entity);
            long entityId = ctx.SaveChanges();
            return entityId;
        }

        public long Delete(long id)
        {
            int entityId = 0;
            var query = ctx.Memories.FirstOrDefault(b => b.MemoryId == id);
            if (query != null)
            {
                ctx.Memories.Remove(query);
                entityId = ctx.SaveChanges();
            }
            return entityId;
        }

        public long Update(long id, Memory item)
        {
            long entityId = 0;
            var entity = ctx.Memories.Find(id);
            if (entity != null)
            {
                entity.Brand = item.Brand;
                entity.SizeGb = item.SizeGb;
                entity.Speed = item.Speed;
                entity.LastModified = DateTime.Now;

                entityId = ctx.SaveChanges();
            }
            return entityId;
        }
    }
}
