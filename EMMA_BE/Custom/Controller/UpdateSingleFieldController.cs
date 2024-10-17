using EMMA.Commons;
using EMMA.Commons.UpdateSingleField;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text;

namespace EMMA_BE.Custom.Controller {
    [ApiController]
    [Route("[controller]")]
    public class UpdateSingleFieldController : ControllerBase {

        protected readonly IConfiguration _configuration;
        protected readonly QueryBase _query;

        public UpdateSingleFieldController(IConfiguration configuration) {
            _configuration = configuration;
            _query = new QueryBase(_configuration);
        }

        [HttpPost("UpdateStringField")]
        public IActionResult UpdateStringField(UpdateStringFieldData data) {
            try {
                StringBuilder query = new($"UPDATE [{data.TableName}] SET [{data.FieldName}] = @FIELD_VALUE WHERE [ID] = @ID");
                List<SqlParameter> parameters = [];

                parameters.Add(new SqlParameter("@FIELD_VALUE", data.FieldValue));
                parameters.Add(new SqlParameter("@ID", data.Id));

                _query.UpdateSingleField(query, parameters);

                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateIntField")]
        public IActionResult UpdateIntField(UpdateIntFieldData data) {
            try {
                StringBuilder query = new($"UPDATE [{data.TableName}] SET [{data.FieldName}] = @FIELD_VALUE WHERE [ID] = @ID");
                List<SqlParameter> parameters = [];

                parameters.Add(new SqlParameter("@FIELD_VALUE", data.FieldValue));
                parameters.Add(new SqlParameter("@ID", data.Id));

                _query.UpdateSingleField(query, parameters);

                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
