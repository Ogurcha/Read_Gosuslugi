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
    public class BillManager : IBillsManager
    {
        private readonly IGosuslugiPayClient _gosuslugiPayClient;
        private readonly IComplexMapper _complexMapper;
        private readonly IMapper _mapper;

        public BillManager(IGosuslugiPayClient gosuslugiPayClient,
            IComplexMapper complexMapper,
            IMapper mapper)
        {
            _gosuslugiPayClient = gosuslugiPayClient;
            _complexMapper = complexMapper;
            _mapper = mapper;
        }

        public async Task<ServiceBills> GetBillsByPassport(string passport)
        {
            var response = await _gosuslugiPayClient.GetFinesByPassport(passport);
            var result = _mapper.Map<ServiceBills>(FilterBills(response));
            return result;
        }

        public async Task<ServiceBills> GetBillsBySnils(string snils)
        {
            var response = await _gosuslugiPayClient.GetFinesBySnils(snils);
            var result = _mapper.Map<ServiceBills>(FilterBills(response));
            return result;
        }

        private IEnumerable<Bill> FilterBills(GosuslugiPayResponse gosuslugiPayResponse)
            => gosuslugiPayResponse.Bills?.Where(x => x.ServiceCategory?.Name == "Счет за услуги") ?? new List<Bill>();
    }
}
