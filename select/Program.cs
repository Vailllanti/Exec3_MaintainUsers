using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace select
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"SELECT id,name,dateOfBirth FROM USERS where id > @id ORDER BY id ASC";
			var connection = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBulider().AddInt("id", 0).Build();
				DataTable dataTable = connection.Select(sql,parameters);
				
				foreach(DataRow row in dataTable.Rows)
				{
					int id = row.Field<int>("id");
					string name = row.Field<string>("name");
					DateTime dateOfBirth = row.Field<DateTime>("dateOfBirth");

					Console.WriteLine($"ID = {id},Name = {name},Date of birth = {dateOfBirth}");
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
