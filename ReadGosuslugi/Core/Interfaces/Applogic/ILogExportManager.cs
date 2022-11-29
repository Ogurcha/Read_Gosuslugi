using System;
using System.Threading.Tasks;

namespace ReadGosuslugi.Core.Interfaces.Applogic
{
    public interface ILogExportManager
    {
        /// <summary>
        /// Get serialized json logs for today
        /// </summary>
        Task<string> GetLogDump();

        /// <summary>
        /// Get serialized json logs for specific day
        /// </summary>
        Task<string> GetLogDump(DateTime date);
    }
}
