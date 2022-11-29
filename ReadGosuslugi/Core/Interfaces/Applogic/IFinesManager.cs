using ReadGosuslugi.Core.Dtos;
using System.Threading.Tasks;

namespace ReadGosuslugi.Core.Interfaces.Applogic
{
    public interface IFinesManager
    {
        Task<Fines> GetFinesByInn(string inn);
        Task<Fines> GetFinesByPassport(string passport);
        Task<Fines> GetFinesBySts(string sts);
    }
}
