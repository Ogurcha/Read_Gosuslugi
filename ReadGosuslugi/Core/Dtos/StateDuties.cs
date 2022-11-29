using System;
using System.Collections.Generic;

namespace ReadGosuslugi.Core.Dtos
{
    public class StateDuties : List<StateDuty>
    {
    }

    /// <summary>
    /// Госпошлина
    /// </summary>
    public class StateDuty : IHasPrice
    {
        /// <summary>
        /// Дата госпошлины
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Сумма госпошлины (рубли)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание госпошлины (рубли)
        /// </summary>
        public string Info { get; set; }
    }
}
