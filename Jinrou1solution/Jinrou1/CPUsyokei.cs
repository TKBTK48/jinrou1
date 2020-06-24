using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    public class CPUsyokei
    {
        int syokeisya;
        public int syokei(string zentai, int honnin, int num, string[] indicatearray, string[] unindicatearray)
        {
            string[] rolearray = zentai.Trim().Split(',');
            int[] array = new int[num];
            for (int i2 = 0; i2 < num; i2++)
            {
                array[i2] = i2;
            }

            if (rolearray[honnin] == "人狼")
            {
                while (true)
                {
                    int[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    syokeisya = line[0];
                    if (rolearray[line[0]] != "人狼")
                    {
                        break;
                    }
                }

            }
            else if (rolearray[honnin] == "狂人")
            {
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
                        syokeisya = line[0];
                        if (syokeisya != honnin)
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
                        syokeisya = line[0];
                        if (syokeisya != honnin)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                while (true)
                {
                    for (int i4 = 0; i4 < num; i4++)
                    {
                        if (indicatearray[i4] == "人狼")
                        {
                            Array.Resize(ref array, array.Length + 1);
                            array[array.Length - 1] = i4;
                        }
                    }
                    int[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    syokeisya = line[0];
                    if (syokeisya != honnin)
                    {
                        break;
                    }
                }
            }

            return syokeisya;

        }
    }
}
