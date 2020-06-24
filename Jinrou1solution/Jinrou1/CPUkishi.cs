using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    public class CPUkishi
    {
        int protect;
        public int kishi(string zentai, int honnin, int num, string[] indicatearray, string[] unindicatearray)
        {
            string[] rolearray = zentai.Trim().Split(',');
            int[] array = new int[num];
            for (int i2 = 0; i2 < num; i2++)
            {
                array[i2] = i2;
            }
            try
            {
                while (true)
                {
                    for (int i3 = 0; i3 < num; i3++)
                    {
                        if (unindicatearray[i3] == "市民")
                        {
                            Array.Resize(ref array, array.Length + 1);
                            array[array.Length - 1] = i3;
                        }
                    }
                    int[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    protect = line[0];
                    if (protect != honnin)
                    {
                        break;
                    }
                }
            }
            catch
            {
                while (true)
                {
                    int[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    protect = line[0];
                    if (protect != honnin)
                    {
                        break;
                    }
                }
            }
            return protect;
        }
    }
}
