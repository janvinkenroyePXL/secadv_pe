using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class PoemsController : ControllerBase
    {
        private IPoemData _poemData;

        public PoemsController(IPoemData poemData)
        {
            _poemData = poemData;
        }

        [HttpGet]
        [Authorize("admin")]
        public IActionResult Get()
        {
            var model = _poemData.GetAll();
            return new ObjectResult(model);
        }

        [HttpGet]
        [Route("{id?}")]
        [Authorize("admin")]
        public IActionResult GetById(int id)
        {
            var model = _poemData.Get(id);
            if(model == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(model);
            }
        }
    }
}
