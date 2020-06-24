using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    public class rolestatementcheck
    {
        public int rolestatementFlg = 1;
        public void rolestatementchecker(string input)
        {
            if(input== "予言")
            {
                rolestatementFlg = 0;
            }
            else if (input == "騎士")
            {
                rolestatementFlg = 0;
            }
            else if (input == "霊媒")
            {
                rolestatementFlg = 0;
            }
            else if (input == "市民")
            {
                rolestatementFlg = 0;
            }
            else
            {
                rolestatementFlg = 1;
            }
        }
    }
}
