using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.TestLabArchive
{
    public class TestLab4
    {
        public static void Lab4a()
        {
            Console.WriteLine("HUNT TEST\n");
            var o = new Orc() { Name = "Gorbag", Rage = 7 };
            Console.WriteLine(o.Greeting());
            for (int i = 0; i < 10; i++)
            {
                o.Hunt();
                Console.WriteLine(o.Greeting());
            }

            Console.WriteLine("\nSING TEST\n");
            var e = new Elf("Legolas", agility: 2);
            Console.WriteLine(e.Greeting());
            for (int i = 0; i < 10; i++)
            {
                e.Sing();
                Console.WriteLine(e.Greeting());
            }

            Console.WriteLine("\nPOWER TEST\n");
            Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
            foreach (Creature creature in creatures)
            {
                Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
            }
        }


    public static void Lab4b()
        {
            object[] myObjects = {
            new Animals() { Description = "dogs"},
            new Birds { Description = "  eagles ", Size = 10 },
            new Elf("e", 15, -3),
            new Orc("morgash", 6, 4)
           };
            Console.WriteLine("\nMy objects:");
            foreach (var o in myObjects) Console.WriteLine(o);
            /*
                My objects:
                ANIMALS: Dogs <3>
                BIRDS: Eagles (fly+) <10>
                ELF: E## [10][0]
                ORC: Morgash [6][4]
            */
        }

    }
}
