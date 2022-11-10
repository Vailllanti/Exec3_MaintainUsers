using ISpan.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string Sql = @"INSERT INTO users(Name,Account,Password,DateOfBirth,Height) 
									Values(@Name,@Account,@Password,@DateOfBirth,@Height)";
			var connection = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBulider()
								.AddNVarchar("Name",50,"Angus")
								.AddNVarchar("Account",50,"Vaillanti")
								.AddNVarchar("Password",50,"password")
								.AddDatetime("DateOfBirth", new DateTime(1999,10,14))
								.AddInt("Height",178)
								.Build();
				connection.ExecuteNonQuery(Sql,parameters);
				Console.WriteLine("紀錄已新增");
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
