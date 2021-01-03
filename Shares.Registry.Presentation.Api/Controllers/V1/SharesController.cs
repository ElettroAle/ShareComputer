using Microsoft.AspNetCore.Mvc;

using Shares.Registry.Business.Computer.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shares.Registry.Presentation.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SharesController : ControllerBase
    {
        private readonly IComputeService computeService;
        public SharesController(IComputeService computeService) => this.computeService = computeService;

        // GET: api/v1/<SharesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/v1/<SharesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/v1/<SharesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/v1/<SharesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v1/<SharesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
