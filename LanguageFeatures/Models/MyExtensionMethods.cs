using System;
using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (var prod in products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }
        // public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> products, decimal minPrice)
        // {
        //     foreach (var prod in products)
        //     {
        //         if ((prod?.Price ?? 0) >= minPrice)
        //         {
        //             yield return prod;
        //         }
        //     }
        // }

        // public static IEnumerable<Product> FilterByName(this IEnumerable<Product> productEnum, char firstLetter)
        // {
        //     foreach (Product prod in productEnum)
        //     {
        //         if (prod?.Name?[0] == firstLetter)
        //         {
        //             yield return prod;
        //         }
        //     }
        // }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product, bool> selector)
        {
            foreach (var prod in products)
            {
                if (selector(prod))
                    yield return prod;
            }
        }
    }
}