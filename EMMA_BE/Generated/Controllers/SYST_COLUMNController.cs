using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated {
	[ApiController]
	[Route("[controller]")]
	public class SYST_COLUMNController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly SYST_COLUMN_Query _query;

		public SYST_COLUMNController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new SYST_COLUMN_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<SYST_COLUMN_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(SYST_COLUMN_Record record) {
			try {
				_query.UpdateByKey(record.ID, new SYST_COLUMN_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}