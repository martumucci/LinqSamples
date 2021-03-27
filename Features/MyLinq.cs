using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Linq
{
    public static class MyLinq
    {
        /// <summary>
        /// returns de amount of items in an IEnumerable of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static int Count<T>(this IEnumerable<T> sequence) //Extension method
        {
            int count = 0;
            foreach (var item in sequence)
            {
                count += 1;
            }
            return count;
        }
    }
}
