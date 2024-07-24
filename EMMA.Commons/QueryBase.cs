using Microsoft.Extensions.Configuration;

namespace EMMA.Commons {
	public class QueryBase {

		private readonly IConfiguration _configuration;
		protected readonly string connectionString;

		public QueryBase(IConfiguration configuration) {
			_configuration = configuration;
			connectionString = _configuration.GetConnectionString("locale") ?? throw new Exception($"Stringa di connessione [locale] non trovata");
		}
	}
}
