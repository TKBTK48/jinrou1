using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    public class CPUyogen
    {
        public int indicateFlg = 100;
        public int unindicateFlg = 100;
        public string mes = "";
        public string CPUyogensya(string honto, string zentai, int zibun, int num)
        {
            string[] rolearray = zentai.Trim().Split(',');
            if (honto == "予言")
            {
                int[] array = new int[num];
                while (true)
                {
                    for (int i1 = 0; i1 < num; i1++)
                    {
                        array[i1] = i1;
                    }
                    int[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    int uranaunum = line[0];
                    if(zibun==uranaunum)
                    {
                        continue;
                    }
                    else if (rolearray[uranaunum] == "人狼")
                    {
                        mes = $"プレイヤー（{zibun + 1}）によってプレイヤー（{uranaunum + 1}）が人狼と申告されました";
                        indicateFlg = uranaunum;
                        break;
                    }
                    else
                    {
                        mes = $"プレイヤー（{zibun + 1}）によってプレイヤー（{uranaunum + 1}）が市民と申告されました";
                        unindicateFlg = uranaunum;
                        break;
                    }
                }

            }
            else
            {
                int[] array = new int[num];
                int[] line = new int[num];
                int[] kakuritsu = new int[3] { 0, 0, 1};
                int[] kakuline = kakuritsu.OrderBy(i => Guid.NewGuid()).ToArray();
                if (kakuline[0] == 1)
                {
                    while (true)
                    {
                        for (int i5 = 0; i5 < num; i5++)
                        {
                            array[i5] = i5;
                            line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                        }
                        if (zibun == line[0])
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    mes = $"プレイヤー（{zibun + 1}）によってプレイヤー（{line[0] + 1}）が市民と申告されました";
                    unindicateFlg = line[0];
                }
                else
                {
                    while (true)
                    {
                        for (int i2 = 0; i2 < num; i2++)
                        {
                            array[i2] = i2;
                            line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                        }
                        if (zibun == line[0])
                        {
                            continue;
                        }
                        else if (rolearray[line[0]] == "人狼")
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    mes = $"プレイヤー（{zibun + 1}）によってプレイヤー（{line[0] + 1}）が人狼と申告されました";
                    indicateFlg = line[0];
                }
            }
            return mes;

        }
    }
}
