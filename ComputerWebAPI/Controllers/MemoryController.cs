using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerLibrary.Models;
using ComputerDAL;
using Microsoft.Extensions.Logging;


namespace ComputerWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MemoryController : Controller
    {
        private readonly ILogger<MemoryController> _logger;
        private IDataRepository<Memory, long> _iRepo;

        public MemoryController(IDataRepository<Memory, long> repo, ILogger<MemoryController> logger)
        {
            _iRepo = repo;
            _logger = logger;
        }

        // GET api/[Controller]
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogDebug("GET api/memory");
            IActionResult ret = null;

            var item = _iRepo.GetAll();

            if (item == null)
            {
                ret = NotFound();
            }
            else
            {
                ret = new ObjectResult(item);
            }

            _logger.LogDebug("GET api/memory returned : {0}", ret);
            return ret;
        }

        // GET api/[Controller]/5
        [HttpGet("{id}", Name = "GetMemory")]
        public IActionResult Get(long id)
        {
            _logger.LogDebug("GET api/memory/{0}", id);
            IActionResult ret = null;

            var item = _iRepo.Get(id);

            if (item == null)
            {
                ret = NotFound();
            }
            else
            {
                ret = new ObjectResult(item);
            }
            _logger.LogDebug("GET api/memory/{0} returned : {1}", id, ret);
            return ret;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Memory item)
        {
            _logger.LogDebug("GET api/memory/post");
            IActionResult ret = null;

            if (item == null)
            {
                ret = BadRequest();
            }
            else
            {
                var id = _iRepo.Add(item);
                ret = CreatedAtRoute("GetMemory", new { id = item.MemoryId }, item);
            }

            _logger.LogDebug("GET api/memory/post returned : {0}", ret);
            return ret;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Memory item)
        {
            _logger.LogDebug("GET api/memory/Put");
            IActionResult ret = null;

            if (item == null)
            {
                ret = BadRequest();
            }

            else
            {
                var updatedId = _iRepo.Update(item.MemoryId, item);

                if (updatedId == 0)
                {
                    ret = NotFound();
                }
                else
                {
                    ret = new ObjectResult(updatedId);
                }
            }
            _logger.LogDebug("GET api/memory/put returned : {0}", ret);
            return ret;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogDebug("GET api/memory/Delete");
            IActionResult ret = null;

            var item = _iRepo.Get(id);

            if (item == null)
            {
                ret = NotFound();
            }
            else
            {
                var deletedId = _iRepo.Delete(id);
                ret = new ObjectResult(deletedId);
            }
            _logger.LogDebug("GET api/memory/Delete returned : {0}", ret);
            return ret;
        }
    }
}