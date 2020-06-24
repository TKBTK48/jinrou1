using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    public class CPUjinrou
    {
        int kill;
        public int jinrou(string zentai, int honnin, int num, string[] statementarray)
        {
            string[] rolearray = zentai.Trim().Split(',');
            int[] array = new int[num];
            for (int i2 = 0; i2 < num; i2++)
            {
                array[i2] = i2;
            }
                while (true)
                {
                    for (int i3 = 0; i3 < num; i3++)
                    {
                        if (statementarray[i3] != "市民")
                        {
                            for (int i4 = 0; i4 < 10; i4++)
                            {
                                Array.Resize(ref array, array.Length + 1);
                                array[array.Length - 1] = i3;
                            }
                        }
                    }
                    int[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    kill = line[0];
                    if (rolearray[kill] != "人狼")
                    {
                        break;
                    }
                }
            return kill;
        }
    }
}
