using ReadGosuslugi.Core.Dtos;
using ReadGosuslugi.Core.Extensions;
using ReadGosuslugi.ExternalInterop.PayGosuslugi;
using System;

namespace ReadGosuslugi.Mapping
{
    public class ComplexMapper : IComplexMapper
    {
        public ComplexMapper()
        {
        }

        public Fines Map(GosuslugiPayResponse source)
        {
            var result = new Fines();
            foreach (var fkPayment in source.FkPayments.OrEmptyIfNull())
            {
                var timeStamp = fkPayment.PayDate;
                var dt = DateTime.FromBinary(timeStamp);
                result.Add(new Fine { Price = fkPayment.Ammount, Date = dt, Info = fkPayment.Purpose });
            }
            return result;
        }
    }
}
