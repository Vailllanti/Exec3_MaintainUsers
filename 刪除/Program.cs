using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 刪除
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"Delete From users where id=@id";
			var connection = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBulider().AddInt("id",2).Build();
				connection.ExecuteNonQuery(sql, parameters);

				Console.WriteLine("紀錄已刪除");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
