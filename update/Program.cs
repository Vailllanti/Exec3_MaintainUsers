using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace update
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"UPDATE @Name,@Password FROM users WHERE id = @id";
			var connection = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBulider()
									.AddNVarchar("Name",50,"123")
									.AddNVarchar("Password",50,"4446")
									.AddInt("id",3)
									.Build();
				connection.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("修改成功");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
