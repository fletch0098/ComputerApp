using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerLibrary.Models;
using ComputerDAL;


namespace ComputerWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ComputerController : Controller
    {
        private IDataRepository<Computer, long> _iRepo;
        public ComputerController(IDataRepository<Computer, long> repo)
        {
            _iRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Computer> Get()
        {
            return _iRepo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ret = _iRepo.Get(id);
            if (ret != null)
            {
                return Ok(ret);
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST api/values
        [HttpPost]
        public long Post([FromBody]Computer computer)
        {
            return _iRepo.Add(computer);
        }

        // POST api/values
        [HttpPut]
        public long Put([FromBody]Computer computer)
        {
            return _iRepo.Update(computer.ComputerId, computer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}