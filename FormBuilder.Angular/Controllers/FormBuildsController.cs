using FormBuilder.Core.Application.AppService.Interfaces;
using FormBuilder.Shared.Kernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FormBuilder.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormBuildsController : ControllerBase
    {
        private readonly IFormBuildQueryAppService _formBuildQuery;

        public FormBuildsController(IFormBuildQueryAppService formBuildQuery)
        {
            _formBuildQuery = formBuildQuery;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return Ok(await _formBuildQuery.PaginateAsync(new PageFilter(pageNumber, pageSize)));
        }
    }
}