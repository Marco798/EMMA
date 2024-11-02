using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EMMA_BE.Generated.Controller {
	[ApiController]
	[Route("[controller]")]
	public class SYST_COMBOController : ControllerBase {

		protected readonly IConfiguration _configuration;
		protected readonly SYST_COMBO_Query _query;

		public SYST_COMBOController(IConfiguration configuration) {
			_configuration = configuration;
			_query = new SYST_COMBO_Query(_configuration);
		}

		[HttpGet("SelectAll")]
		public IActionResult SelectAll() {
			try {
				List<SYST_COMBO_Record> _Record_List = _query.SelectAll();
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectAll_CustomRecord")]
		public IActionResult SelectAll_CustomRecord(List<SYST_COMBO_Field>? fields = null) {
			try {
				List<SYST_COMBO_NullRecord> _Record_List = _query.SelectAll(fields);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectWithSimpleCriteria")]
		public IActionResult SelectWithSimpleCriteria(SYST_COMBO_NullRecord nullRecord) {
			try {
				List<SYST_COMBO_Record> _Record_List = _query.SelectWithSimpleCriteria(nullRecord);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("SelectWithSimpleCriteria_CustomRecord")]
		public IActionResult SelectWithSimpleCriteria_CustomRecord([FromQuery] SYST_COMBO_NullRecord nullRecord, [FromQuery] List<SYST_COMBO_Field>? fields = null) {
			try {
				List<SYST_COMBO_NullRecord> _Record_List = _query.SelectWithSimpleCriteria(nullRecord, fields);
				return Ok(_Record_List);
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("UpdateByKey")]
		public IActionResult UpdateByKey(SYST_COMBO_IdRecord record) {
			try {
				_query.UpdateByKey(record.ID, new SYST_COMBO_NullRecord(record));

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("Insert")]
		public IActionResult Insert(SYST_COMBO_BaseRecord record) {
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
