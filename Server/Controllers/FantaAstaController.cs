using FantaAsta.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FantaAsta.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FantaAstaController : ControllerBase
    {

        private readonly ILogger<FantaAstaController> logger;

        public FantaAstaController(ILogger<FantaAstaController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("[action]")]
        public IEnumerable<Giocatore> GetGiocatori()
        {
            return null;
        }
    }
}
