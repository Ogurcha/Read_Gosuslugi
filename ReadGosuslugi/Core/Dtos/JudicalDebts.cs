using System;
using System.Collections.Generic;

namespace ReadGosuslugi.Core.Dtos
{
    public class JudicalDebts : List<JudicalDebt>
    {
    }

    /// <summary>
    /// Судебная задолженность
    /// </summary>
    public class JudicalDebt : IHasPrice
    {
        /// <summary>
        /// Сумма задолженности (рубли)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание задолженности (рубли)
        /// </summary>
        public string Info { get; set; }
    }
}
