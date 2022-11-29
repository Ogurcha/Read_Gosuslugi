namespace ReadGosuslugi.Core.Dtos
{
    public interface IHasPrice
    {
        /// <summary>
        /// Сумма задолженности (рубли)
        /// </summary>
        decimal Price { get; set; }
    }
}