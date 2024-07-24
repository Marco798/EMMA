using Microsoft.AspNetCore.Mvc;

namespace EMMA_BE.Generated {
	[ApiController]
	[Route("[controller]")]
	public class SYST_MENUController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly SYST_MENU_Query _query;

		public SYST_MENUController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new SYST_MENU_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<SYST_MENU_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}
