using Microsoft.Extensions.Configuration;
using NLog;
using System.Data.SqlClient;

namespace SingleRun {
	public class Program {
		protected static string connectionString = string.Empty;
		protected static readonly ILogger logger = LogManager.GetCurrentClassLogger();
		protected static SqlConnection connection = new();

		static void Main() {
			try {
				Initialize();
				logger.Info(new string('=', 100));
				logger.Info($"Inizio Elaborazione - {DateTime.Now}");
				logger.Info(new string('=', 100));

				CaricaEstrattoConto_Banca task = new();
				task.Run();

				logger.Info(new string('=', 100));
				logger.Info("Elaborazione terminata");
				logger.Info(new string('=', 100));

			}
			catch (Exception ex) {
				logger.Error(ex);
			}
			Console.ReadLine();
		}

		private static void Initialize() {
			IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory() + @"\..\..\..\").AddJsonFile("appsettings.json").Build();
			connectionString = configuration.GetSection("ConnectionStrings")["locale"] ?? throw new Exception();
			connection = new(connectionString);
		}
	}
}
