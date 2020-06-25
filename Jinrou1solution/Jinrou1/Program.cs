using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jinrou1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("人狼ゲームを開始します");
            Console.WriteLine("準備できればEnterを押してください");
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("役割分担");
            Console.WriteLine("５⇒人狼１　狂人１　予言１　騎士１　市民１");
            Console.WriteLine("６⇒人狼１　狂人１　予言１　騎士１　市民２");
            Console.WriteLine("７⇒人狼１　狂人１　予言１　騎士１　市民３");
            Console.WriteLine("８⇒人狼２　狂人０　予言１　霊媒１　騎士１　市民３");
            Console.WriteLine("準備できればEnterを押してください");
            Console.WriteLine();
            Console.ReadLine();

            //全体人数
            int playernum1 = 0;
            while (true)
            {
                Console.WriteLine("ゲーム全体の人数を入力してください（CPU含む）※5～8");
                string zentaiplayer = Console.ReadLine();
                var zentaiplayer1 = new zentaiplayercheck();
                string mes1 = zentaiplayer1.zentaiplayerchecker(zentaiplayer);
                playernum1 = zentaiplayer1.zentaiplayer;
                Console.WriteLine(mes1);
                if (zentaiplayer1.zentaiplayercheckFlg == 0)
                {
                    break;
                }
            }

            //参加人数
            int playernum2 = 0;
            while (true)
            {
                Console.WriteLine("プレイヤー人数を入力してください");
                string player = Console.ReadLine();
                var player1 = new playercheck();
                string mes1 = player1.playerchecker(player, playernum1);
                playernum2 = player1.player;
                if (player1.playercheckFlg == 0)
                {
                    break;
                }
            }

            //役割分担
            //５⇒人狼１　狂人１　予言１　騎士１　市民１
            //６⇒人狼１　狂人１　予言１　騎士１　市民２
            //７⇒人狼１　狂人１　予言１　騎士１　市民３
            //８⇒人狼２　狂人０　予言１　霊媒１　騎士１　市民３
            var role1 = new role();
            string rolearray1 = role1.divisionrole(playernum1);
            string[] rolearray = rolearray1.Trim().Split(',');
            for (int i1 = 0; i1 < playernum2; i1++)
            {
                Console.WriteLine($"あなた（プレイヤー{i1 + 1}）の役割は{rolearray[i1]}です。");
                Console.WriteLine("確認できればEnterを押してください");
                Console.ReadLine();
            }

            string[] life = new string[playernum1];
            for (int life1 = 0; life1 < playernum1; life1++)
            {
                life[life1] = "生存";
            }
            //人狼同士の確認
            if (playernum1 == 8)
            {
                Console.WriteLine("人狼は互いに仲間を確認してもらいます");
                Console.WriteLine("準備できればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                for (int x1 = 0; x1 < playernum2; x1++)
                {
                    if (rolearray[x1] == "人狼")
                    {
                        Console.WriteLine($"あなた（プレイヤー{x1 + 1}）の仲間を教えます。");
                        Console.WriteLine("準備できればEnterを押してください");
                        Console.WriteLine();
                        Console.ReadLine();
                        for (int x2 = 0; x2 < playernum1; x2++)
                        {
                            if (rolearray[x2] == "人狼" && x1 != x2)
                            {
                                Console.WriteLine($"プレイヤー{x2 + 1}が仲間の人狼です。");
                                Console.WriteLine("確認できればEnterを押してください");
                                Console.WriteLine();
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }


            //プレイヤー役割表明
            Console.WriteLine("各プレイヤーは自らの役割を表明してください");
            Console.WriteLine("準備できればEnterを押してください");
            Console.WriteLine();
            Console.ReadLine();
            string[] statementarray = new string[playernum1];
            string[] statementx = new string[playernum2];
            for (int i4 = 0; i4 < playernum2; i4++)
            {
                while (true)
                {
                    Console.WriteLine($"あなた（プレイヤー{i4 + 1}）は自らの役割を表明してください");
                    Console.WriteLine("予言, 騎士, 霊媒, 市民のいずれかを入力してください");
                    statementx[i4] = Console.ReadLine();
                    statementarray[i4] = statementx[i4];
                    var rolesss = new rolestatementcheck();
                    rolesss.rolestatementchecker(statementx[i4]);
                    if (rolesss.rolestatementFlg == 0)
                    {
                        Console.WriteLine("入力完了しました");
                        Console.WriteLine($"{statementx[i4]}で登録しました");
                        Console.WriteLine("準備できればEnterを押してください");
                        Console.WriteLine();
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("値が不正なので再入力してください");
                    }
                }
            }
            //CPUプレイヤー役割表明
            //本物⇒rolearray 表面上⇒statementarray
            for (int i5 = playernum2; i5 < playernum1; i5++)
            {
                var CPUs = new CPUstatement();
                statementarray[i5] = CPUs.CPUstatementchecker(rolearray[i5], playernum1);
                Console.WriteLine($"プレイヤー{i5 + 1}）は{statementarray[i5]}を名乗りました");
                Console.WriteLine("確認できればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
            }
            string[] indicatearray = new string[playernum1];
            string[] unindicatearray = new string[playernum1];
            int beforeprotect = 50;


            //
            //&&life[]!="死亡"
            //ルーティン開始
            //予言の発言
            while (true)
            {
                Console.WriteLine("昼になりました");
                Console.WriteLine("確認できればEnterを押してください");
                Console.ReadLine();
                //プレイヤーが予言者だった場合の人狼の確認
                Console.WriteLine("予言者に占いをしてもらいます");
                Console.WriteLine("準備できればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                for (int i2 = 0; i2 < playernum2; i2++)
                {
                    if (rolearray[i2] == "予言" && life[i2] == "生存")
                    {
                        Console.WriteLine($"あなた（プレイヤー{i2 + 1}）に予言を与えます。");
                        Console.WriteLine("準備できればEnterを押してください");
                        Console.WriteLine();
                        Console.ReadLine();
                        while (true)
                        {
                            Console.WriteLine($"あなた（プレイヤー{i2 + 1}）は占いたいプレイヤーの番号を半角数字で入力してください");
                            string uranaiint = Console.ReadLine();

                            try
                            {
                                int uranainum = int.Parse(uranaiint) - 1;
                                Console.WriteLine($"プレイヤー({uranainum + 1})を占います");
                                Console.WriteLine("準備できればEnterを押してください");
                                Console.WriteLine();
                                Console.ReadLine();
                                if (rolearray[uranainum] == "人狼")
                                {
                                    Console.WriteLine($"プレイヤー({uranainum + 1})は人狼です");
                                }
                                else
                                {
                                    Console.WriteLine($"プレイヤー({uranainum + 1})は市民です");
                                }
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("値が不正です");
                            }
                        }

                    }
                }
                Console.WriteLine("予言者は確認しました");
                Console.WriteLine("準備できればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                Console.WriteLine("予言者と名乗り出た人は占いの内容を教えてください");
                Console.WriteLine("確認できればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                int indicate1 = 100;
                for (int i6 = 0; i6 < playernum2; i6++)
                {
                    if (statementx[i6] == "予言" && life[i6] != "死亡")
                    {
                        while (true)
                        {
                            Console.WriteLine($"予言者と名乗ったプレイヤー（{i6 + 1}）は占ったプレイヤーの番号(半角数字)を入力してください");
                            string indi = Console.ReadLine();
                            try
                            {
                                indicate1 = int.Parse(indi) - 1;
                                Console.WriteLine("Enterを押してください");
                                Console.WriteLine();
                                Console.ReadLine();
                                while (true)
                                {
                                    Console.WriteLine("人狼ですか？市民ですか？");
                                    string zinrouorsimin = Console.ReadLine();
                                    if (zinrouorsimin == "人狼")
                                    {
                                        indicatearray[indicate1] = "人狼";
                                        indicatearray[i6] = "人狼";
                                        break;
                                    }
                                    else if (zinrouorsimin == "市民")
                                    {
                                        unindicatearray[indicate1] = "市民";
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("値が不正です");
                                    }
                                }
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("値が不正です");
                            }
                        }
                    }
                }
                //CPU予言者
                //本物⇒rolearray 表面上⇒statementarray
                for (int i7 = playernum2; i7 < playernum1; i7++)
                {
                    if (statementarray[i7] == "予言" && life[i7] != "死亡")
                    {
                        string mes1 = "";
                        var CPUyogenvar = new CPUyogen();
                        mes1 = CPUyogenvar.CPUyogensya(rolearray[i7], rolearray1, i7, playernum1);
                        Console.WriteLine(mes1);
                        if (CPUyogenvar.indicateFlg != 100)
                        {
                            indicatearray[CPUyogenvar.indicateFlg] = "人狼";
                            indicatearray[i7] = "人狼";
                        }
                        else
                        {
                            unindicatearray[CPUyogenvar.unindicateFlg] = "市民";
                        }
                    }
                }



                //夕方⇒処刑
                Console.WriteLine("夕方になりました");
                Console.WriteLine("処刑すべき人を多数決で決めなければなりません");
                Console.WriteLine("準備ができればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                int[] syokeitouhyou = new int[playernum1];
                for (int xx8 = 0; xx8 < playernum1; xx8++)
                {
                    syokeitouhyou[xx8] = 0;
                }
                for (int i8 = 0; i8 < playernum2; i8++)
                {
                    if (life[i8] != "死亡")
                    {
                        while (true)
                        {
                            Console.WriteLine("処刑すべきプレイヤーを半角数字で入力して投票してください");
                            string ippyo = Console.ReadLine();
                            try
                            {
                                int touhyo = int.Parse(ippyo) - 1;
                                syokeitouhyou[touhyo] = syokeitouhyou[touhyo] + 1;
                                if (life[touhyo] != "死亡")
                                {
                                    Console.WriteLine($"プレイヤー({ippyo})への投票が登録されました");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("そのプレイヤーは既に死亡しています");
                                    continue;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("不正な値です");
                                continue;
                            }
                        }
                    }
                }
                //CPU処刑投票
                for (int i9 = playernum2; i9 < playernum1; i9++)
                {
                    if (life[i9] != "死亡")
                    {
                        int touhyo;
                        while (true)
                        {
                            var cpusyokeiman = new CPUsyokei();
                            touhyo = cpusyokeiman.syokei(rolearray1, i9, playernum1, indicatearray, unindicatearray);
                            if (life[touhyo] != "死亡")
                            {
                                break;
                            }
                        }
                        syokeitouhyou[touhyo] = syokeitouhyou[touhyo] + 1;
                        //Console.WriteLine($"プレイヤー{i9 + 1}がプレイヤー{touhyo + 1}に投票しました");
                    }
                }
                //投票結果
                int syokeisikkou = 100;
                int syokeisikkouFlg = 0;
                int maxti = syokeitouhyou.Max();
                for (int i10 = 0; i10 < playernum1; i10++)
                {
                    if (syokeitouhyou[i10] == maxti)
                    {
                        syokeisikkouFlg = syokeisikkouFlg + 1;
                        syokeisikkou = i10;
                    }
                }
                Console.WriteLine("確認できればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                if (syokeisikkouFlg > 1)
                {
                    Console.WriteLine("処刑は執行しませんでした");
                    syokeisikkou = 100;
                }
                else
                {
                    Console.WriteLine($"プレイヤー{syokeisikkou + 1}に処刑が執行されました");
                    life[syokeisikkou] = "死亡";
                }


                //死亡確認
                for (int y1 = 0; y1 < playernum2; y1++)
                {
                    if (life[y1] == "死亡")
                    {
                        Console.WriteLine($"残念ながらあなた(プレイヤー({y1 + 1})は死亡しています");
                    }
                }


                //
                //騎士の防衛
                //本物⇒rolearray 表面上⇒statementarray
                Console.WriteLine("確認できればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                Console.WriteLine("騎士の防衛フェイズに入ります");
                Console.WriteLine("準備ができればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                int protect = 100;
                for (int i11 = 0; i11 < playernum2; i11++)
                {
                    if (rolearray[i11] == "騎士" && life[i11] != "死亡")
                        while (true)
                        {
                            Console.WriteLine($"騎士であるあなた（プレイヤー({i11 + 1})）は防衛するプレイヤーの番号を英数字で選んでください");

                            try
                            {
                                protect = int.Parse(Console.ReadLine()) - 1;
                                if (protect < 0 || playernum1 < protect)
                                {
                                    Console.WriteLine("入力した値が不正です");
                                    continue;
                                }
                                else if (life[protect] == "死亡")
                                {
                                    Console.WriteLine("そのプレイヤーは既に死亡しています");
                                    continue;
                                }
                                else if (protect == i11)
                                {
                                    Console.WriteLine("自分を守ることはできません");
                                    continue;
                                }
                                else if (beforeprotect == protect)
                                {
                                    Console.WriteLine("昨晩守った人物を守ることはできません");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"プレイヤー({protect + 1})を守ります");
                                    break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("値が不正です");
                                continue;
                            }
                        }
                }
                //騎士がCPUの場合
                for (int i12 = playernum2; i12 < playernum1; i12++)
                {
                    if (rolearray[i12] == "騎士" && life[i12] != "死亡")
                    {
                        while (true)
                        {
                            var cpukishiman = new CPUkishi();
                            protect = cpukishiman.kishi(rolearray1, i12, playernum1, indicatearray, unindicatearray);
                            if (beforeprotect != protect && life[protect] != "死亡")
                            {
                                break;
                            }
                        }
                    }
                }

                Console.WriteLine("騎士の防衛対象が決まりました");
                Console.WriteLine("準備ができればEnterを押してください");
                Console.WriteLine();
                beforeprotect = protect;


                //
                //
                //人狼
                Console.WriteLine("夜になりました");
                Console.WriteLine("人狼が市民を襲います");
                Console.WriteLine("準備ができればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();
                int kill = 200;

                //人狼がCPUの場合
                for (int i14 = playernum2; i14 < playernum1; i14++)
                {
                    if (rolearray[i14] == "人狼" && life[i14] != "死亡")
                    {
                        while (true)
                        {
                            var killer = new CPUjinrou();
                            kill = killer.jinrou(rolearray1, i14, playernum1, statementarray);
                            if (life[kill] != "死亡")
                            {
                                break;
                            }
                        }
                    }
                }

                //人狼がプレイヤーの場合
                for (int i13 = 0; i13 < playernum2; i13++)
                {
                    if (rolearray[i13] == "人狼" && life[i13] != "死亡")
                        while (true)
                        {
                            Console.WriteLine($"人狼であるあなた（プレイヤー({i13 + 1})）は殺害するプレイヤーの番号を英数字で選んでください");

                            try
                            {
                                kill = int.Parse(Console.ReadLine()) - 1;
                                if (kill < 0 || playernum1 < kill)
                                {
                                    Console.WriteLine("入力した値が不正です");
                                    continue;
                                }
                                else if (life[kill] == "死亡")
                                {
                                    Console.WriteLine("そのプレイヤーは既に死亡しています");
                                    continue;
                                }
                                else if (kill == i13)
                                {
                                    Console.WriteLine("自分を殺害することはできません");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine($"プレイヤー({kill + 1})を殺害します");
                                    break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("値が不正です");
                                continue;
                            }
                        }
                }
                Console.WriteLine("人狼が殺害対象を殺害しました");
                Console.WriteLine("準備ができればEnterを押してください");
                Console.WriteLine();



                //
                //
                //
                Console.WriteLine("朝になりました");
                Console.WriteLine("準備ができればEnterを押してください");
                Console.WriteLine();
                if (protect == kill || kill == 200)
                {
                    Console.WriteLine("昨日の犠牲者はいませんでした");
                }
                else
                {
                    Console.WriteLine($"昨日はプレイヤー{kill + 1}が人狼に殺害されました");
                    life[kill] = "死亡";
                }


                //死亡確認
                for (int y2 = 0; y2 < playernum2; y2++)
                {
                    if (life[y2] == "死亡")
                    {
                        Console.WriteLine($"残念ながらあなた(プレイヤー({y2 + 1})は死亡しています");
                    }
                }

                Console.WriteLine("準備ができればEnterを押してください");
                Console.WriteLine();
                Console.ReadLine();

                if (syokeisikkou != 100)
                {
                    for (int i14 = 0; i14 < playernum2; i14++)
                    {
                        if (rolearray[i14] == "霊媒" && life[i14] != "死亡")
                        {
                            Console.WriteLine("霊媒に昨日の処刑者が人狼か市民かを教えます");
                            Console.WriteLine("準備ができればEnterを押してください");
                            Console.WriteLine();
                            Console.WriteLine($"霊媒であるプレイヤー({i14 + 1})に昨日の処刑者が人狼か市民かを教えます");
                            Console.WriteLine("準備ができればEnterを押してください");
                            Console.WriteLine();
                            if (rolearray[syokeisikkou] == "人狼")
                            {
                                Console.WriteLine($"昨日の処刑者であるプレイヤー({syokeisikkou + 1})は人狼です");
                            }
                            else
                            {
                                Console.WriteLine($"昨日の処刑者であるプレイヤー({syokeisikkou + 1})は市民です");
                            }
                        }
                    }
                    for (int i15 = playernum2; i15 < playernum1; i15++)
                    {
                        if (statementarray[i15] == "霊媒" && life[i15] != "死亡")
                        {
                            Console.WriteLine("霊媒に昨日の処刑者が人狼か市民かを教えます");
                            Console.WriteLine("準備ができればEnterを押してください");
                            Console.WriteLine();
                            Console.WriteLine($"霊媒であるプレイヤー({i15 + 1})が昨日の処刑者が人狼か市民かを教えます");
                            Console.WriteLine("準備ができればEnterを押してください");
                            Console.ReadLine();
                            if (rolearray[i15] == "霊媒")
                            {
                                if (rolearray[syokeisikkou] == "人狼")
                                {
                                    Console.WriteLine($"昨日の処刑者であるプレイヤー({syokeisikkou + 1})は人狼です");
                                }
                                else
                                {
                                    Console.WriteLine($"昨日の処刑者であるプレイヤー({syokeisikkou + 1})は市民です");
                                }
                            }
                            else
                            {
                                if (rolearray[syokeisikkou] == "人狼")
                                {
                                    Console.WriteLine($"昨日の処刑者であるプレイヤー({syokeisikkou + 1})は市民です");
                                }
                                else
                                {
                                    Console.WriteLine($"昨日の処刑者であるプレイヤー({syokeisikkou + 1})は人狼です");
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("ゲームマスターが勝敗条件を確認しています。。。");
                Console.WriteLine("準備ができればEnterを押してください");
                Console.ReadLine();

                int livingjinrou = 0;
                int livingnum = 0;
                int livingperson = 0;
                for (int i16 = 0; i16 < playernum1; i16++)
                {
                    if (life[i16] == "生存")
                    {
                        livingnum = livingnum + 1;
                    }
                }

                for (int i17 = 0; i17 < playernum1; i17++)
                {
                    if (life[i17] == "生存" && rolearray[i17] == "人狼")
                    {
                        livingjinrou = livingjinrou + 1;
                    }
                }
                livingperson = livingnum - livingjinrou;

                if (livingjinrou >= livingperson)
                {
                    Console.WriteLine("人狼陣営（人狼、狂人）の勝利です");
                    for (int i18 = 0; i18 < playernum1; i18++)
                    {
                        Console.WriteLine($"プレイヤー({i18 + 1})は{rolearray[i18]}でした");
                    }
                    break;
                }
                else if (livingjinrou == 0)
                {
                    Console.WriteLine("市民陣営（市民、霊媒、予言、騎士）の勝利です");
                    for (int i19 = 0; i19 < playernum1; i19++)
                    {
                        Console.WriteLine($"プレイヤー({i19 + 1})は{rolearray[i19]}でした");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("勝負はまだ未決着です");
                    Console.WriteLine("準備ができればEnterを押してください");
                    Console.ReadLine();
                    continue;
                }

            }
        }
    }
}

