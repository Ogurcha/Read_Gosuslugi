using ReadGosuslugi.ExternalInterop.PayGosuslugi;
using System.Threading.Tasks;

namespace ReadGosuslugi.Core.Interfaces
{
    public interface IGosuslugiPayClient
    {
        Task<GosuslugiPayResponse> GetFinesByInn(string inn);
        Task<GosuslugiPayResponse> GetFinesByPassport(string passport);
        Task<GosuslugiPayResponse> GetFinesBySts(string sts);
        Task<GosuslugiPayResponse> GetFinesBySnils(string snils);
    }
}
