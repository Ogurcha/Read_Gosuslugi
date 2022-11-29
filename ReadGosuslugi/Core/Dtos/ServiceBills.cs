using System.Collections.Generic;

namespace ReadGosuslugi.Core.Dtos
{
    public class ServiceBills : List<ServiceBill>
    {
    }

    /// <summary>
    /// Счет
    /// </summary>
    public class ServiceBill : IHasPrice
    {
        /// <summary>
        /// Сумма счета (рубли)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание счета (рубли)
        /// </summary>
        public string Info { get; set; }
    }
}
