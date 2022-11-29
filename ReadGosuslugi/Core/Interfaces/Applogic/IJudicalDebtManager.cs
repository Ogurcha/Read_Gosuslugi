using ReadGosuslugi.Core.Dtos;
using System.Threading.Tasks;

namespace ReadGosuslugi.Core.Interfaces.Applogic
{
    public interface IJudicalDebtManager
    {
        Task<JudicalDebts> GetJudicalDebtsByPassport(string passport);
        Task<JudicalDebts> GetJudicalDebtsByInn(string inn);
        Task<JudicalDebts> GetJudicalDebtsBySnuls(string snils);
    }
}