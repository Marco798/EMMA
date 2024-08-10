using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated {
	[ApiController]
	[Route("[controller]")]
	public class FLOW_INPUT_FILEController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly FLOW_INPUT_FILE_Query _query;

		public FLOW_INPUT_FILEController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new FLOW_INPUT_FILE_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<FLOW_INPUT_FILE_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(FLOW_INPUT_FILE_Record record) {
			try {
				_query.UpdateByKey(record.ID, new FLOW_INPUT_FILE_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}
