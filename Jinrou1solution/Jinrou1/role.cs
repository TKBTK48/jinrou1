using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    public class role
    {
        public string divisionrole(int number)
        {
            string mes = "";
            //役割分担
            //５⇒人狼１　狂人１　予言１　騎士１　市民１
            //６⇒人狼１　狂人１　予言１　騎士１　市民２
            //７⇒人狼１　狂人１　予言１　騎士１　市民３
            //８⇒人狼２　狂人０　予言１　霊媒１　騎士１　市民３
            if (number == 5)
            {
                string[] rolearray = new string[5] { "人狼", "狂人", "予言", "騎士" ,"市民" };
                string[] roleline = rolearray.OrderBy(i => Guid.NewGuid()).ToArray();
                mes = $"{roleline[0]},{roleline[1]},{roleline[2]},{roleline[3]},{roleline[4]}";
            }
            else if (number == 6)
            {
                string[] rolearray = new string[6] { "人狼", "狂人", "予言", "騎士", "市民", "市民" };
                string[] roleline = rolearray.OrderBy(i => Guid.NewGuid()).ToArray();
                mes = $"{roleline[0]},{roleline[1]},{roleline[2]},{roleline[3]},{roleline[4]},{roleline[5]}";
            }
            else if (number == 7)
            {
                string[] rolearray = new string[7] { "人狼", "狂人", "予言", "騎士", "市民", "市民", "市民" };
                string[] roleline = rolearray.OrderBy(i => Guid.NewGuid()).ToArray();
                mes = $"{roleline[0]},{roleline[1]},{roleline[2]},{roleline[3]},{roleline[4]},{roleline[5]},{roleline[6]}";
            }
            else if (number == 8)
            {
                string[] rolearray = new string[8] { "人狼", "人狼", "予言", "騎士", "霊媒", "市民", "市民", "市民" };
                string[] roleline = rolearray.OrderBy(i => Guid.NewGuid()).ToArray();
                mes = $"{roleline[0]},{roleline[1]},{roleline[2]},{roleline[3]},{roleline[4]},{roleline[5]},{roleline[6]},{roleline[7]}";
            }
            return mes;
        }
    }
}
