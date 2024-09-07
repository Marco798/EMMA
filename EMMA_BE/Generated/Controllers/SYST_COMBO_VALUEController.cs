using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated.Controller {
	[ApiController]
	[Route("[controller]")]
	public class SYST_COMBO_VALUEController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly SYST_COMBO_VALUE_Query _query;

		public SYST_COMBO_VALUEController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new SYST_COMBO_VALUE_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<SYST_COMBO_VALUE_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(SYST_COMBO_VALUE_IdRecord record) {
			try {
				_query.UpdateByKey(record.ID, new SYST_COMBO_VALUE_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Insert")]
		public IActionResult Insert(SYST_COMBO_VALUE_BaseRecord record) {
			try {
				_query.Insert(record);

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}