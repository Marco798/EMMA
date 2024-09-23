using System.Data.SqlClient;

namespace EMMA.Commons {
	public interface ICustomSelect_Record {
		public abstract ICustomSelect_Record GetRecord(SqlDataReader reader);
	}
}
