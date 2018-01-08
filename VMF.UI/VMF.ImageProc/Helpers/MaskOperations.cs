using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMF.ImageProc.Exceptions;

namespace VMF.ImageProc.Helpers
{
    public class MaskOperations
    {
        private int sumOfMask(int[] mask)
        {
            int value = 0;
            Parallel.For(0, mask.Length, i =>
            {
                value += mask[i];
            });
            return value;
        }

        public int weightedAverage(int[] imageFragment, int[] mask)
        {
            int sum = sumOfMask(mask);
            int result = 0;
            if(imageFragment.Length == mask.Length)
            {
                throw new BadMaskLengthException();
            }
            Parallel.For(0, imageFragment.Length, i =>
            {
                result = imageFragment[i] * mask[i];
            });
            if (sum != 0)
            {
                return Math.Abs(result / sum);
            }
            return Math.Abs(result);
        }
    }
}
