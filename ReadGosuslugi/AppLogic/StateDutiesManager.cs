using AutoMapper;
using ReadGosuslugi.Core.Dtos;
using ReadGosuslugi.Core.Interfaces;
using ReadGosuslugi.Core.Interfaces.Applogic;
using ReadGosuslugi.ExternalInterop.PayGosuslugi;
using ReadGosuslugi.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ReadGosuslugi.ExternalInterop.PayGosuslugi.GosuslugiPayResponse;

namespace ReadGosuslugi.AppLogic
{
    public class StateDutiesManager : IStateDutiesManager
    {
        private readonly IGosuslugiPayClient _gosuslugiPayClient;
        private readonly IComplexMapper _complexMapper;
        private readonly IMapper _mapper;

        public StateDutiesManager(IGosuslugiPayClient gosuslugiPayClient, IComplexMapper complexMapper, IMapper mapper)
        {
            _gosuslugiPayClient = gosuslugiPayClient;
            _complexMapper = complexMapper;
            _mapper = mapper;
        }

        public async Task<StateDuties> GetDutiesByInn(string inn)
        {
            var response = await _gosuslugiPayClient.GetFinesByInn(inn);
            var result = _mapper.Map<StateDuties>(FilterDebts(response));
            return result;
        }

        public async Task<StateDuties> GetDutiesByPassport(string passport)
        {
            var response = await _gosuslugiPayClient.GetFinesByPassport(passport);
            var result = _mapper.Map<StateDuties>(FilterDebts(response));
            return result;
        }

        public async Task<StateDuties> GetDutiesBySnils(string snils)
        {
            var response = await _gosuslugiPayClient.GetFinesBySnils(snils);
            var result = _mapper.Map<StateDuties>(FilterDebts(response));
            return result;
        }

        private IEnumerable<Bill> FilterDebts(GosuslugiPayResponse gosuslugiPayResponse)
            => gosuslugiPayResponse.Bills?.Where(x => x.ServiceCategory.Name == "Госпошлина") ?? new List<Bill>();
    }
}
