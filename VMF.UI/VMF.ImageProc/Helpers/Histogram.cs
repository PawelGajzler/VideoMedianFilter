using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMF.ImageProc.Helpers
{
    public class Histogram
    {
        private long[] table;
        private long pixelAmount;

        public Histogram(Bitmap image)
        {
            table = new long[256];
            pixelAmount = image.Width * image.Height;
            for(int i=0; i<image.Width; ++i)
            {
                for(int j=0; j<image.Height; ++j)
                {
                    table[image.GetPixel(i, j).R]++;
                }
            }
        }

        public int CalculateThreshhold()
        {
            double minimum = double.MaxValue;
            int threshhold = 0;
            for(int i=0; i<255; ++i)
            {
                double value = CalculateClassVariance(i);
                if (value < minimum)
                {
                    minimum = value;
                    threshhold = i;
                }
            }
            return threshhold;
        }

        private double CalculateClassVariance(int threshhold)
        {
            long[] left = new long[threshhold];
            Array.Copy(table, 0, left, 0, threshhold);
            long[] right = new long[256 - threshhold];
            Array.Copy(table, threshhold, right, 0, 256 - threshhold);

            double weightBack = CalculateWeight(left);
            double weightFore = CalculateWeight(right);
            double meanBack = CalculateMean(left, threshhold, true);
            double meanFore = CalculateMean(right, threshhold, false);
            double varianceBack = CalculateVariance(left, threshhold, meanBack, true);
            double varianceFore = CalculateVariance(right, threshhold, meanFore, false);

            return weightBack * varianceBack + weightFore * varianceFore;
        }

        private double CalculateWeight(long[] table)
        {
            double result = 0;
            for(int i=0; i < table.Length; ++i)
            {
                result = result + table[i];
            }
            return result / pixelAmount;
        }

        private double CalculateMean(long[] table, int threshhold, bool left)
        {
            double value = 0;
            double occurences = 0;
            for(int i=0;i<table.Length; ++i)
            {
                if (left)
                {
                    value = value + table[i] * i;
                }
                else
                {
                    value = value + table[i] * (i + threshhold);
                }
                occurences = occurences + table[i];
            }
            return value / occurences;
        }

        private double CalculateVariance(long[] table, int threshhold, double mean, bool left)
        {
            double value = 0;
            double occurences = 0;
            for(int i=0; i < table.Length; ++i)
            {
                if (left)
                {
                    value = value + Math.Pow(i - mean, 2) * table[i];
                }
                else
                {
                    value = value + Math.Pow(i - mean + threshhold, 2) * table[i];
                }
                occurences = occurences + table[i];
            }
            return value / occurences;
        }
    }
}
