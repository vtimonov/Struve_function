using System;
using System.Collections.Generic;
using System.Text;

namespace Struve_function
{
    class Program
    {
        private static double _StruveFunctionHv(double v, double z)
        {
            try
            {
                double k = 100;
                double fraction = 0;
                double fractionFactor = Math.Pow((0.5 * z), v + 1);
                for (int i = 0; i < k; ++i)
                {
                    double fractionTopPart = Math.Pow(-1, i) * Math.Pow((0.5 * z), (2 * i));
                    double fractionBottomPart = _GammaEuler(i + (1.5)) * _GammaEuler(i + v + (1.5));
                    fraction = fraction + (fractionTopPart / fractionBottomPart);
                }
                double _Hv = fractionFactor * fraction;
                return _Hv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static double _StruveFunctionLv(double v, double z)
        {
            try
            {
                int iterationSum = 100;
                double fraction = 0;
                double fractionFactor = Math.Pow((0.5 * z), v + 1);
                for (int i = 0; i < iterationSum; ++i)
                {
                    double fractionTopPart = 1 * Math.Pow((0.5 * z), (2 * i));
                    double fractionBottomPart = _GammaEuler(i + (1.5)) * _GammaEuler(i + v + (1.5));
                    fraction = fraction + (fractionTopPart / fractionBottomPart);
                }
                double _Lv = fractionFactor * fraction;
                return _Lv;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static double _GammaEuler(double z)
        {
            try
            {
                double gamma = 1;
                if (z > 0)
                {
                    int iterationSum = 10000;
                    for (int i = 1; i < iterationSum; ++i)
                    {
                        gamma = gamma * (Math.Pow((1 + ((double)1 / i)), z) * Math.Pow((1 + ((double)z / i)), -1));
                    }
                    gamma = ((double)1 / z) * gamma;
                }
                else return 0;
                return gamma;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
