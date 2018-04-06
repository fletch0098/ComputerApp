using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerLibrary.Models;
using ComputerDAL;
using Microsoft.Extensions.Logging;


namespace ComputerWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ComputerController : Controller
    {
        private readonly ILogger<ComputerController> _logger;
        private IDataRepository<Computer, long> _iRepo;

        public ComputerController(IDataRepository<Computer, long> repo, ILogger<ComputerController> logger)
        {
            _iRepo = repo;
            _logger = logger;
        }

        // GET api/[Controller]
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogDebug("GET api/computer");
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

            _logger.LogDebug("GET api/computer returned : {0}", ret);
            return ret;
        }

        // GET api/[Controller]/5
        [HttpGet("{id}", Name = "GetComputer")]
        public IActionResult Get(long id)
        {
            _logger.LogDebug("GET api/computer/{0}", id);
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
            _logger.LogDebug("GET api/computer/{0} returned : {1}",id, ret);
            return ret;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Computer item)
        {
            _logger.LogDebug("GET api/computer/post");
            IActionResult ret = null;

            if (item == null)
            {
                ret = BadRequest();
            }
            else
            {
                var id = _iRepo.Add(item);
                ret = CreatedAtRoute("GetComputer", new { id = item.ComputerId }, item);
            }

            _logger.LogDebug("GET api/computer/post returned : {0}", ret);
            return ret;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Computer item)
        {
            _logger.LogDebug("GET api/computer/Put");
            IActionResult ret = null;

            if (item == null)
            {
                ret = BadRequest();
            }

            else
            {
                var updatedId = _iRepo.Update(item.ComputerId, item);

                if (updatedId == 0)
                {
                    ret = NotFound();
                }
                else
                {
                    ret = new ObjectResult(updatedId);
                }
            }
            _logger.LogDebug("GET api/computer/put returned : {0}", ret);
            return ret;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogDebug("GET api/computer/Delete");
            IActionResult ret = null;

            var item = _iRepo.Get(id);

            if (item == null)
            {
                ret = NotFound();
            }
            else
            {
                var deletedId =_iRepo.Delete(id);
                ret = new ObjectResult(deletedId);
            }
            _logger.LogDebug("GET api/computer/Delete returned : {0}", ret);
            return ret;
        }
    }
}