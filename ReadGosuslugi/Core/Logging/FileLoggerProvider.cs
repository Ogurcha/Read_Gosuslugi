using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System.Reflection;

namespace ReadGosuslugi.Core.Logging
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private Logger _serilogLogger;
        private readonly IConfiguration _config;
        private readonly string STR_OUTPUT_TEMPLATE = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} " 
            + Assembly.GetCallingAssembly().GetName().Name 
            + " [{Level:u3}] {Message:lj}{NewLine}{Exception}";

        public FileLoggerProvider(IConfiguration config)
        {
            _config = config;

            _serilogLogger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.File(_config.GetValue<string>("LOGGER_TEXT_FILE_PATH"),
                        outputTemplate: STR_OUTPUT_TEMPLATE,
                        rollingInterval: RollingInterval.Day)
                .WriteTo.File(new JsonFormatter(),
                         _config.GetValue<string>("LOGGER_JSON_FILE_PATH"),
                        rollingInterval: RollingInterval.Day,
                        shared: true)
                .CreateLogger();
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName)
        {
            var _logger = new Serilog.Extensions.Logging.SerilogLoggerFactory(_serilogLogger).CreateLogger(categoryName);
            return _logger;
        }

        public void Dispose()
        {
            _serilogLogger.Dispose();
        }
    }
}
