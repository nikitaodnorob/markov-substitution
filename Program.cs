using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsBonus
{
    struct Podstanovka
    {
        public string first;
        public string second;
        public bool isFinish;
    }

    class Program
    {
        /*static string ApplyPodstanovka(string s, Podstanovka p)
        {
            int pos = s.IndexOf(p.first);
            int len = p.first.Length;
            s = s.Remove(pos, len - pos + 1).Insert(pos, p.second);
        }*/
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     ********************************************************");
            Console.WriteLine("     *   Нормальные алгоритмы Маркова - бонусное задание    *");
            Console.WriteLine("     *    Выполнил: студент 2 курса 8 группы Однороб Н.     *");
            Console.WriteLine("     ********************************************************\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Введите количество подстановок в схеме: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("     Введите подстановки построчно в формате:");
            Console.WriteLine("          <слово1> => <слово2>");
            Console.WriteLine("                 или ");
            Console.WriteLine("          <слово1> =>. <слово2> (для заключительной)");
            Console.Write    ("     Для обозначения пустого слова используйте \"");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\\eps");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\" (без кавычек)");
            Console.ForegroundColor = ConsoleColor.White;

            string str = null;
            List<Podstanovka> pods = new List<Podstanovka>();
            for (int i = 0; i < n; i++)
            {
                Podstanovka tmp = new Podstanovka();
                str = Console.ReadLine();
                if (str.Contains("=>."))
                {
                    int pos1 = str.IndexOf("=>.");
                    tmp.first = str.Substring(0, pos1).Trim().Replace("\\eps","");
                    tmp.second = str.Substring(pos1 + 3).Trim().Replace("\\eps", "");
                    tmp.isFinish = true;
                }
                else if (str.Contains("=>"))
                {
                    int pos1 = str.IndexOf("=>");
                    tmp.first = str.Substring(0, pos1).Trim().Replace("\\eps", "");
                    tmp.second = str.Substring(pos1 + 2).Trim().Replace("\\eps", "");
                    tmp.isFinish = false;
                }
                pods.Add(tmp);
            }

            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите исходное слово или ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\\quit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" для выхода. Пустая строка обозначается ");
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("\\eps");
                Console.ForegroundColor = ConsoleColor.White;
                str = Console.ReadLine().Replace("\\eps", "");
                if (str == "\\quit") break;
                bool isBreak = false;
                int col = 0;
                while (true)
                {
                    bool isApplied = false;
                    //Ищем подходящую подстановку
                    foreach (var p in pods)
                    {
                        int pos = str.IndexOf(p.first);
                        int len = p.first.Length;
                        if (pos >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            /*if (pos != 0)*/
                            Console.Write(str.Substring(0, pos));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(p.first);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(str.Substring(pos + len));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" => ");
                            str = str.Remove(pos, len).Insert(pos, p.second);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(str);
                            isApplied = true;
                            if (p.isFinish) isBreak = true;
                            break;
                        }
                    }
                    if (!isApplied || isBreak) break;
                    col++;
                    if (col % 20 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выполнено 20 итераций");
                        Console.Write("Чтобы выполнить еще 20 итераций, введите ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("go");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(", для выхода любую другую строку");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (Console.ReadLine() != "go") break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("=====================================");
            }
        }
    }
}
