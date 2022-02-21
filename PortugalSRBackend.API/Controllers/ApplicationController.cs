using Microsoft.AspNetCore.Mvc;
using PortugalSRBackend.Core.Interfaces.Services;

namespace PortugalSRBackend.API.Controllers
{
    /// <summary>
    /// Controller to enable the desired route on the Test requirements
    /// It doesnt follow patterns/conventions
    /// </summary>
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IStoryService service;

        public ApplicationController(IStoryService service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Best20()
        {
            return Ok(await service.GetBest20Async());
        }
    }
}
