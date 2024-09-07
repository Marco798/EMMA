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
				logger.Info($"Inizio Elaborazione - {DateTime.Now}");
				logger.Info(new string('=', 100));

				BANK_AcquireFlow task = new() {
					inputParams = new() {
						FileName = @"C:\EMMA\SingleRun\INPUT\EstrattoConto_BMED_Dicembre2017.csv"
					}
				};

				task.Run();

				logger.Info(new string('=', 100));
				logger.Info("Elaborazione terminata");
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
