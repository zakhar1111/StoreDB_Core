﻿using Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.Utils
{
    public class CartCalculator : ICalculate
    {
        private IDiscount discounter;
        public CartCalculator(IDiscount discountParam)
        {
            discounter = discountParam;
        }
        public decimal SumarizeProducts(IEnumerable<CartLine> products)
        {
            var total = products.Sum(x => x.Product.Price * x.Quantity);
            return discounter.ApplyDiscount(total);
        }
    }
}
