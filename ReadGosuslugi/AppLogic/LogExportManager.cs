using Microsoft.Extensions.Configuration;
using ReadGosuslugi.Core.Interfaces.Applogic;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ReadGosuslugi.AppLogic
{
    public class LogExportManager : ILogExportManager
    {
        private readonly IConfiguration _config;

        public LogExportManager(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Get serialized json logs for today
        /// </summary>
        public async Task<string> GetLogDump()
        {
            var path = _config.GetValue<string>("LOGGER_JSON_FILE_PATH");
            var fileName = path.Substring(0, path.LastIndexOf('.')) + DateTime.Now.ToString("yyyyMMdd") + Path.GetExtension(path);

            if (File.Exists(fileName))
            {
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            return null;
        }

        /// <summary>
        /// Get serialized json logs for specific day
        /// </summary>
        public async Task<string> GetLogDump(DateTime date)
        {
            var path = _config.GetValue<string>("LOGGER_JSON_FILE_PATH");
            var fileName = path.Substring(0, path.LastIndexOf('.')) + date.ToString("yyyyMMdd") + Path.GetExtension(path);

            if (File.Exists(fileName))
            {
                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            return null;
        }
    }
}
