using System.Collections;
using System.Collections.Generic;
using Model.Entity;

namespace View
{
    public class Print
    {
        private const string LIST_IS_EMPTY = "Sorry, no products with these parameters...\n";

        public static string Show(IEnumerable list)
        {
            IEnumerator iterator = list.GetEnumerator();
            string result = "";

            while (iterator.MoveNext())
            {
                result += iterator.Current + "\n";
            }

            return result.Length != 0 ? result : LIST_IS_EMPTY;
        }
    }
}