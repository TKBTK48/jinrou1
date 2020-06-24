using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    public class zentaiplayercheck
    {
        public int zentaiplayer = 0;
        public int zentaiplayercheckFlg = 1; 
        public string zentaiplayerchecker(string input)
        {
            string mes = "";
            try
            {
                 zentaiplayer = int.Parse(input);
                if (4 < zentaiplayer && zentaiplayer < 9)
                {
                    mes = $"全体では{zentaiplayer}人で開始します";
                    zentaiplayercheckFlg = 0;
                }
                else
                {
                    mes = "入力しなおしてください";
                }
            }
            catch
            {
                mes = "入力しなおしてください";
            }
            return mes;
        }
    }
}
