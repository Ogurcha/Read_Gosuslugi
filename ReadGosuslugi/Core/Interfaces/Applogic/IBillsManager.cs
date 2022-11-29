using ReadGosuslugi.Core.Dtos;
using System.Threading.Tasks;

namespace ReadGosuslugi.Core.Interfaces.Applogic
{
    public interface IBillsManager
    {
        Task<ServiceBills> GetBillsByPassport(string passport);
        Task<ServiceBills> GetBillsBySnils(string snils);
    }
}
