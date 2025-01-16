using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.TestLabArchive
{
    public class TestLab3
    {
        public static void Lab3a()
        {
            Elf c = new() { Name = "   Shrek    ", Level = 20 };
            Console.WriteLine(c.Greeting());
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("  ", -5);
            Console.WriteLine(c.Greeting());
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("  donkey ") { Level = 7 };
            Console.WriteLine(c.Greeting());
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("Puss in Boots – a clever and brave cat.");
            Console.WriteLine(c.Greeting());
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("a                            troll name", 5);
            Console.WriteLine(c.Greeting());
            c.Upgrade();
            Console.WriteLine(c.Info);

            var a = new Animals() { Description = "   Cats " };
            Console.WriteLine(a.Info);

            a = new() { Description = "Mice           are great", Size = 40 };
            Console.WriteLine(a.Info);
        }

        public static void Lab3b()
        {
            Elf c = new("Shrek", 7);
            Console.WriteLine(c.Greeting());

            Console.WriteLine("\n* Up");
            Console.WriteLine(c.Go(Direction.Up));

            Console.WriteLine("\n* Right, Left, Left, Down");
            Direction[] directions = {
            Direction.Right, Direction.Left, Direction.Left, Direction.Down
            };
            string[] goTable = c.Go(directions);
            foreach (var go in goTable)
            {
                Console.WriteLine(go);
            }

            Console.WriteLine("\n* LRL");
            string[] goTable2 = c.Go("LRL");
            foreach (var go in goTable2)
            {
                Console.WriteLine(go);
            }

            Console.WriteLine("\n* xxxdR lyyLTyu");
            string[] goTable3 = c.Go("xxxdR lyyLTyu");
            foreach (var go in goTable3)
            {
                Console.WriteLine(go);
            }
        }
    }
}
