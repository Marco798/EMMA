using Microsoft.AspNetCore.Mvc;

namespace EMMA_BE.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class TestController : ControllerBase {
		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			return Ok();
		}
	}
}
