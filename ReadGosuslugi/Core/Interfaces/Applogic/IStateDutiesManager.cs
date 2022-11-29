using ReadGosuslugi.Core.Dtos;
using System.Threading.Tasks;

namespace ReadGosuslugi.Core.Interfaces.Applogic
{
    public interface IStateDutiesManager
    {
        Task<StateDuties> GetDutiesByPassport(string passport);
        Task<StateDuties> GetDutiesByInn(string inn);
        Task<StateDuties> GetDutiesBySnils(string snils);
    }
}
