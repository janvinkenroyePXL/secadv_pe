using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace teachersapi.Controllers
{
    [Route("fiets")]
    [Authorize]
    public class BicycleController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<string>()
            {
                "Het Hollands ventieldopje (Dunlop) is een veel voorkomend ventiel. Vaak zie je deze terug op een stadsfiets. Ze zijn eenvoudig op te pompen.",
                "Het Frans ventieldopje komt vaak voor bij sportieve fietsen zoals racefietsen. Dit ventieldopje is al iets moeilijker om op te pompen.",
                "Het Auto ventieldopje is een populair ventieldopje, voornamelijk in de auto branche. Het lijkt er op dat dit type ventieldopje steeds meer verdwijnt bij fietsen."
            });
        }
    }
}
