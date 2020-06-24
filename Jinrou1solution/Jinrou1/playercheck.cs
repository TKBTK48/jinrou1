using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    class playercheck
    {
        public int player = 0;
        public int playercheckFlg = 1;
        public string playerchecker(string input,int saidai)
        {

            string mes = "";
            try
            {
                player = int.Parse(input);
                if (0 < player && player <= saidai)
                {
                    mes = $"プレイヤーは{player}人で開始します";
                    playercheckFlg = 0;
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
