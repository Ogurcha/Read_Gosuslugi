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
    /// <summary>
    /// менеджеры со всей бизнес логикой
    /// </summary>
    public class FinesManager : IFinesManager
    {
        private readonly IGosuslugiPayClient _gosuslugiPayClient;
        private readonly IComplexMapper _complexMapper;
        private readonly IMapper _mapper;

        public FinesManager(IGosuslugiPayClient gosuslugiPayClient,
            IComplexMapper complexMapper,
            IMapper mapper)
            
        {
            _gosuslugiPayClient = gosuslugiPayClient;
            _complexMapper = complexMapper;
            _mapper = mapper;
        }

        public async Task<Fines> GetFinesByInn(string inn)
        {
            var response = await _gosuslugiPayClient.GetFinesByInn(inn);
            var result = _mapper.Map<Fines>(FilterDebts(response));
            return result;
        }

        public async Task<Fines> GetFinesByPassport(string passport)
        {
            var response = await _gosuslugiPayClient.GetFinesByPassport(passport);
            var result = _mapper.Map<Fines>(FilterFines(response));
            return result;
        }

        public async Task<Fines> GetFinesBySts(string sts)
        {
            var response = await _gosuslugiPayClient.GetFinesBySts(sts);
            var result = _mapper.Map<Fines>(FilterFines(response));
            return result;
        }

        private IEnumerable<Bill> FilterDebts(GosuslugiPayResponse gosuslugiPayResponse)
            => gosuslugiPayResponse.Bills?.Where(x => x.ServiceCategory?.Name == "Налоговая задолженность") ?? new List<Bill>();

        private IEnumerable<Bill> FilterFines(GosuslugiPayResponse gosuslugiPayResponse)
            => gosuslugiPayResponse.Bills?.Where(x => x.ServiceCategory?.Name == "Штраф") ?? new List<Bill>();
    }
}
