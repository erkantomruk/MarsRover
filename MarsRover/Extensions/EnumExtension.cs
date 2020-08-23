﻿using System;

namespace MarsRover.Extensions
{
    public static class EnumExtension
    {
        public static T Next<T>(this T src) where T : struct
        {
            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static T Previous<T>(this T src) where T : struct
        {
            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) - 1;
            return (j == -1) ? Arr[Arr.Length-1] : Arr[j];
        }
    }
}
