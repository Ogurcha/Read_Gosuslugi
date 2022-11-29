using AutoMapper;
using ReadGosuslugi.Core.Dtos;
using System;
using static ReadGosuslugi.ExternalInterop.PayGosuslugi.GosuslugiPayResponse;

namespace ReadGosuslugi.Mappers
{
    public class GosuslugiPayMappingProfile : Profile
    {
        public GosuslugiPayMappingProfile()
        {
            CreateMap<Bill, Fine>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(bill => DateTime.FromBinary(bill.BillDate)))
                .ForMember(dest => dest.Info, opt => opt.MapFrom(bill => bill.BillName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(bill => bill.Amount));

            CreateMap<Bill, JudicalDebt>()
                .ForMember(dest => dest.Info, opt => opt.MapFrom(bill => bill.BillName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(bill => bill.Amount));

            CreateMap<Bill, ServiceBill>()
                .ForMember(dest => dest.Info, opt => opt.MapFrom(bill => bill.BillName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(bill => bill.Amount));

            CreateMap<Bill, StateDuty>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(bill => DateTime.FromBinary(bill.BillDate)))
                .ForMember(dest => dest.Info, opt => opt.MapFrom(bill => bill.BillName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(bill => bill.Amount));
        }
    }
}
