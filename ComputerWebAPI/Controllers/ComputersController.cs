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

        // GET api/[Controller]
        [HttpGet]
        public IActionResult GetAll()
        {
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

            return ret;
        }

        // GET api/[Controller]/5
        [HttpGet("{id}", Name = "GetComputer")]
        public IActionResult Get(long id)
        {
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

            return ret;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Computer item)
        {
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

            return ret;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Computer item)
        {
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

            return ret;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
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

            return ret;
        }
    }
}