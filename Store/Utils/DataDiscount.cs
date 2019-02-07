using System;

namespace Store.Utils
{
    public class DataDiscount : IDiscount
    {
        public decimal ApplyDiscount(decimal totalSum)
        {
            if (IsOddDay())
            {
                totalSum -= totalSum / 10;
            }
            return totalSum;
        }

        bool IsOddDay()
        {
            var day = DateTime.Now.Day;
            return day % 2 != 0;
        }
    }
}
