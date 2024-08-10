using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated {
	[ApiController]
	[Route("[controller]")]
	public class SYST_TABLEController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly SYST_TABLE_Query _query;

		public SYST_TABLEController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new SYST_TABLE_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<SYST_TABLE_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(SYST_TABLE_Record record) {
			try {
				_query.UpdateByKey(record.ID, new SYST_TABLE_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}
