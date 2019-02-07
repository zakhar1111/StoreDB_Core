using Store.Models;
using System.Collections.Generic;

namespace Store.Utils
{
    public class Repository
    {
        private static List<CartLine> responses = new List<CartLine>();
        public static IEnumerable<CartLine> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(CartLine response)
        {
            responses.Add(response);
        }
    }
}
