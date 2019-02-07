using Store.Models;
using System.Collections.Generic;

namespace Store.Utils
{
    public interface ICalculate
    {
        decimal SumarizeProducts(IEnumerable<CartLine> products);
    }
}
