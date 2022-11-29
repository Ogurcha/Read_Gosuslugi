using ReadGosuslugi.Core.Dtos;
using ReadGosuslugi.ExternalInterop.PayGosuslugi;

namespace ReadGosuslugi.Mapping
{
    public interface IComplexMapper
    {
        Fines Map(GosuslugiPayResponse source);
    }
}