﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _52_KingGambit
{
    class Program
    {
        static void Main(string[] args)
        {
            King king = new King(Console.ReadLine());
            king.AttackedKing += king.Attack;
            List<RoyalGuard> guards = new List<RoyalGuard>();
            Console.ReadLine().Split().ToList().ForEach(x => guards.Add(new RoyalGuard(x)));
            List<Footman> footmen = new List<Footman>();
            Console.ReadLine().Split().ToList().ForEach(x => footmen.Add(new Footman(x)));
            guards.ForEach(guard => king.AttackedKing += guard.Attack);
            footmen.ForEach(fm => king.AttackedKing += fm.Attack);
            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();
                switch (input[0])
                {
                    case "Attack": king.UnderAttack(new EventArgs()); break;
                    case "Kill":
                        if (guards.Select(x => x.Name).Contains(input[1]))
                        {
                            var guard = guards.Where(x => x.Name == input[1]).First();
                            king.AttackedKing -= guard.Attack;
                            guards.Remove(guard);
                        }
                        else
                        {
                            var fm = footmen.Where(x => x.Name == input[1]).First();
                            king.AttackedKing -= fm.Attack;
                            footmen.Remove(fm);
                        }
                        break;
                    default: return;
                }
            }
        }
    }
}
