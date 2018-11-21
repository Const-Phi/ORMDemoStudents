using System.Collections.Generic;

namespace ORMDemo.Utilits
{
    internal static class ExtensionMethods
    {
        public static string StringJoin<T>(
            this IEnumerable<T> collection, 
            string delimiter = "; ") 
            => string.Join(delimiter, collection);

        public static void Print(this int value) =>
            System.Console.WriteLine(value);
    }
}
