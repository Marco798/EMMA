using EMMA_BE.Generated;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Data.SqlClient;
using System.Globalization;

namespace EMMA.Tasks {
	public class Program {
		protected static string connectionString = string.Empty;
		protected static readonly ILogger logger = LogManager.GetCurrentClassLogger();
		protected static SqlConnection connection = new();
		protected static IConfiguration configuration;

		protected static readonly CultureInfo cultureInfo_en_US = new("en-US");

		static void Main() {
			try {
				Initialize();
				logger.Info(new string('=', 100));
				logger.Info($"Elaboration START - {DateTime.Now}");
				logger.Info(new string('=', 100));

				//string month = MONTH_Combo.DICEMBRE.Value;
				//BANK_AcquireFlow task = new() {
				//	inputParams = new() {
				//		FileName = $@"C:\Users\marco\Downloads\EstrattoConto_BMED_{month}2020.csv"
				//	}
				//};

				BANK_AssignPatternToStatement task = new();

				task.Run();

				logger.Info(new string('=', 100));
				logger.Info("Elaboration END");
				logger.Info(new string('=', 100));

			}
			catch (Exception ex) {
				logger.Error(ex);
			} finally {
				LogManager.Shutdown();
			}
			Console.ReadLine();
		}

		private static void Initialize() {
			configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory() + @"\..\..\..\").AddJsonFile("appsettings.json").Build();
			connectionString = configuration.GetSection("ConnectionStrings")["locale"] ?? throw new Exception();
			connection = new(connectionString);
		}
	}
}
