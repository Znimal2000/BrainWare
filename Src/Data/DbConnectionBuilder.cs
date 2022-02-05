using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class DbConnectionBuilder
	{
		private readonly string _dbString;
		public DbConnectionBuilder(string dbString)
		{
			_dbString = dbString;
		}

		public SqlConnection CreateDbConnection()
		{
			return new SqlConnection(_dbString);
		}

	}
}
