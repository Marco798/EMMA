using Microsoft.Extensions.Configuration;
using NLog;
using System.Data.SqlClient;
using System.Globalization;

namespace EMMA.Tasks {
	public abstract class MainTask {
		public InputParams inputParams = new();

		protected string connectionString = string.Empty;
		protected static readonly ILogger logger = LogManager.GetCurrentClassLogger();
		protected SqlConnection connection = new();
		protected IConfiguration configuration;

		protected static readonly CultureInfo cultureInfo_en_US = new("en-US");

		protected MainTask() {
			configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory() + @"\..\..\..\").AddJsonFile("appsettings.json").Build();
			connectionString = configuration.GetSection("ConnectionStrings")["locale"] ?? throw new Exception();
			connection = new(connectionString);
		}

		protected static void RunTask<T>(IInputParams _inputParams) where T : MainTask, new() {
			try {
				logger.Info(new string('=', 100));
				logger.Info($"Elaboration START - {DateTime.Now}");
				logger.Info(new string('=', 100));

				T task = new();
				task.SetInputParams(_inputParams);

				task.Run();

				logger.Info(new string('=', 100));
				logger.Info("Elaboration END");
				logger.Info(new string('=', 100));

			}
			catch (Exception ex) {
				logger.Error(ex);
			}
			finally {
				LogManager.Shutdown();
			}
			Console.ReadLine();
		}

		public abstract void Run();

		public abstract void SetInputParams(IInputParams inputParams);

		public class InputParams : IInputParams {

		}
	}
}
