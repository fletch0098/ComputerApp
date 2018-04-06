using System;
using System.Collections.Generic;
using ComputerLibrary.Models;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ComputerDAL
{
    public class ComputerManager : IDataRepository<Computer, long>
    {
        ComputerContext ctx;
        private readonly ILogger<ComputerManager> _logger;

        public ComputerManager(ComputerContext c, ILogger<ComputerManager> logger)
        {
            ctx = c;
            _logger = logger;
        }

        public Computer Get(long id)
        {
            Computer ret = null;

            try
            {
                var query = (from q in ctx.Computers.Include("Memory")
                            where q.ComputerId == id
                            select q).FirstOrDefault();

                if (query != null)
                {
                    ret = query;
                    _logger.LogInformation(string.Format("Computer found for Id {0}", id));
                }
                else
                {
                    _logger.LogWarning(string.Format("No Computer found for Id {0}", id));
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while looking for Computer Id {0}", id);
            }

            return ret;
        }

        public IEnumerable<Computer> GetAll()
        {
            IEnumerable<Computer> ret = null;

            try
            {
                var query = ctx.Computers.Include("Memory");

                if (query != null)
                {
                    ret = query.ToList();
                    _logger.LogInformation("{0} Computers found", ret.Count());
                }
                else
                {
                    _logger.LogWarning("Query yielded no results");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while looking for Computers");
            }

            return ret;
        }

        public long Add(Computer computer)
        {
            long ret = 0;

            try
            {
                computer.LastModified = DateTime.Now;
                ctx.Computers.Add(computer);
                var updatedItems = ctx.SaveChanges();

                if (updatedItems > 0)
                {
                    ret = computer.ComputerId;
                    _logger.LogInformation("Added Computer with Id {0}", ret);
                }
                else
                {
                    _logger.LogWarning("No Computers were added");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while adding to computers");
            }

            return ret;
        }

        public long Delete(long id)
        {
            long ret = 0;

            try
            {
                var computer = ctx.Computers.FirstOrDefault(b => b.ComputerId == id);
                if (computer != null)
                {
                    ctx.Computers.Remove(computer);
                    var updatedItems = ctx.SaveChanges();

                    if (updatedItems > 0)
                    {
                        ret = computer.ComputerId;
                        _logger.LogInformation("Deleted Computer with Id {0}", ret);
                    }
                    else
                    {
                        _logger.LogWarning("No Computers were Deleted");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while Deleting to computers");
            }

            return ret;
        }

        public long Update(long id, Computer item)
        {
            long ret = 0;

            try
            {
                var computer = ctx.Computers.Find(id);
                if (computer != null)
                {
                    computer.ConfiguracionName = item.ConfiguracionName;
                    computer.HardDrive = item.HardDrive;
                    computer.MemoryId = item.MemoryId;
                    computer.Processor = item.Processor;
                    computer.LastModified = DateTime.Now;

                    ret = ctx.SaveChanges();

                    ret = computer.ComputerId;
                    _logger.LogInformation("Updated Computer with Id {0}", ret);
                }
                else
                {
                    _logger.LogWarning("Comuter not found and no Computers were Updated");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while Updating computers");
            }

            return ret;
        }
    }
}
