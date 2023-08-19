using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;

namespace OnionTemplate.Logging
{
	public static class ServiceRegisteration
	{
		public static void AddLoggingRegisteration(this IHostBuilder hostBuilder, IConfiguration configuration)
		{
			Logger log = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();

			hostBuilder.UseSerilog(log);
		}
	}
}