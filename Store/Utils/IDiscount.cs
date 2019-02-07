namespace Store.Utils
{
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal totalSum);
    }
}
