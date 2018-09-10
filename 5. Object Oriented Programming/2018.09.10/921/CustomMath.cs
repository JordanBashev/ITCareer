﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _921
{
    public static class CustomMath
    {
        public static double Sqrt(double num)
        {
            if (num < 0) throw new ArgumentException("Value must be possitive");
            double x =num / 2;
            for (int i = 0; i < 100; i++) x = (x + num / x) / 2d;
            return x;
        }
    }
}
