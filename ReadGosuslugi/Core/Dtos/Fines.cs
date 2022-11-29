using System;
using System.Collections.Generic;

namespace ReadGosuslugi.Core.Dtos
{
    public class Fines : List<Fine>
    {
    }

    /// <summary>
    /// Налоговая задолженность
    /// </summary>
    public class Fine : IHasPrice
    {
        /// <summary>
        /// Дата появления задолженности
        /// </summary>
        public DateTime Date { get; set; }

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
