using System;
using System.Collections.Generic;

namespace Monopoly_Simulation.Common
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this List<T> list)
        {
            Random random = new Random();
            
            int n = list.Count;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + random.Next(n - i);
                T t = list[r];
                list[r] = list[i];
                list[i] = t;
            }
        }
    }
}