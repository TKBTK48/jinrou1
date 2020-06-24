using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    //役割分担
    //５⇒人狼１　狂人１　予言１　騎士１　市民１
    //６⇒人狼１　狂人１　予言１　騎士１　市民２
    //７⇒人狼１　狂人１　予言１　騎士１　市民３
    //８⇒人狼２　狂人０　予言１　霊媒１　騎士１　市民３
    public class CPUstatement
    {
        string mes = "";
        public string CPUstatementchecker(string input,int num)
        {
            if(input == "予言"|| input == "霊媒" || input == "市民")
            {
                mes = input;
            }
            else if (input=="騎士")
            {
                mes = "市民";
            }
            else if(input=="狂人")
            {
                string[] array = new string[6] { "予言", "予言", "予言", "予言", "予言", "市民" };
                string[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                mes = line[0];
            }
            else
            {
                if(num ==5)
                {
                    string[] array = new string[6] { "予言", "予言", "市民", "市民", "市民", "市民" };
                    string[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    mes = line[0];
                }
                else if (num == 6)
                {
                    string[] array = new string[6] { "予言", "予言", "市民", "市民", "市民", "市民" };
                    string[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    mes = line[0];
                }
                else if (num == 7)
                {
                    string[] array = new string[6] { "予言", "予言", "市民", "市民", "市民", "市民" };
                    string[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    mes = line[0];
                }
                else if (num == 8)
                {
                    string[] array = new string[7] { "予言", "予言", "霊媒", "市民", "市民", "市民", "市民" };
                    string[] line = array.OrderBy(i => Guid.NewGuid()).ToArray();
                    mes = line[0];
                }
            }
            return mes;
        }
    }
}
