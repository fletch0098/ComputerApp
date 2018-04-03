using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerLibrary.Models;
using ComputerDAL;


namespace ComputerWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MemoryController : Controller
    {
        private IDataRepository<Memory, long> _iRepo;
        public MemoryController(IDataRepository<Memory, long> repo)
        {
            _iRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Memory> Get()
        {
            return _iRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Memory Get(int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/values
        [HttpPost]
        public long Post([FromBody]Memory entity)
        {
            return _iRepo.Add(entity);
        }

        // POST api/values
        [HttpPut]
        public long Put([FromBody]Memory entity)
        {
            return _iRepo.Update(entity.MemoryId, entity);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}