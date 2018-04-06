using System;
using System.Collections.Generic;
using ComputerLibrary.Models;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ComputerDAL
{
    public class MemoryManager : IDataRepository<Memory, long>
    {
        ComputerContext ctx;
        private readonly ILogger<MemoryManager> _logger;

        public MemoryManager(ComputerContext c, ILogger<MemoryManager> logger)
        {
            ctx = c;
            _logger = logger;
        }

        public Memory Get(long id)
        {
            Memory ret = null;

            try
            {
                var query = (from q in ctx.Memories
                             where q.MemoryId == id
                             select q).FirstOrDefault();

                if (query != null)
                {
                    ret = query;
                    _logger.LogInformation(string.Format("Memory found for Id {0}", id));
                }
                else
                {
                    _logger.LogWarning(string.Format("No Memory found for Id {0}", id));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while looking for Memory Id {0}", id);
            }

            return ret;
        }

        public IEnumerable<Memory> GetAll()
        {
            IEnumerable<Memory> ret = null;

            try
            {
                var query = ctx.Memories;

                if (query != null)
                {
                    ret = query.ToList();
                    _logger.LogInformation("{0} Memorys found", ret.Count());
                }
                else
                {
                    _logger.LogWarning("Query yielded no results");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while looking for Memorys");
            }

            return ret;
        }

        public long Add(Memory memory)
        {
            long ret = 0;

            try
            {
                memory.LastModified = DateTime.Now;
                ctx.Memories.Add(memory);
                var updatedItems = ctx.SaveChanges();

                if (updatedItems > 0)
                {
                    ret = memory.MemoryId;
                    _logger.LogInformation("Added Memory with Id {0}", ret);
                }
                else
                {
                    _logger.LogWarning("No Memorys were added");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding to memorys");
            }

            return ret;
        }

        public long Delete(long id)
        {
            long ret = 0;

            try
            {
                var memory = ctx.Memories.FirstOrDefault(b => b.MemoryId == id);
                if (memory != null)
                {
                    ctx.Memories.Remove(memory);
                    var updatedItems = ctx.SaveChanges();

                    if (updatedItems > 0)
                    {
                        ret = memory.MemoryId;
                        _logger.LogInformation("Deleted Memory with Id {0}", ret);
                    }
                    else
                    {
                        _logger.LogWarning("No Memorys were Deleted");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while Deleting to memorys");
            }

            return ret;
        }

        public long Update(long id, Memory item)
        {
            long ret = 0;

            try
            {
                var entity = ctx.Memories.Find(id);
                if (entity != null)
                {
                    entity.Brand = item.Brand;
                    entity.SizeGb = item.SizeGb;
                    entity.Speed = item.Speed;
                    entity.LastModified = DateTime.Now;

                    ret = ctx.SaveChanges();

                    ret = entity.MemoryId;
                    _logger.LogInformation("Updated Memory with Id {0}", ret);
                }
                else
                {
                    _logger.LogWarning("Comuter not found and no Memorys were Updated");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while Updating memorys");
            }

            return ret;
        }
      
    }
}
