using Microsoft.AspNetCore.Mvc;
using PortugalSRBackend.API.Controllers.Base;
using PortugalSRBackend.Core.Interfaces.Services;

namespace PortugalSRBackend.API.Controllers
{
    public class StoryController : GenericController
    {
        private readonly IStoryService service;

        public StoryController(IStoryService service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        public IActionResult Best20()
        {
            return Ok(service.GetBest20());
        }
    }
}
