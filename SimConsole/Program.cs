using System.Text;
using SimConsole;
using Simulator;
using Simulator.Maps;

Console.OutputEncoding = Encoding.UTF8;

SmallSquareMap map = new(5);
List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
List<Point> points = [new(2, 2), new(3, 1)];
string moves = "dlrludl";

Simulation simulation = new(map, creatures, points, moves);
MapVisualizer mapVisualizer = new(simulation.Map);

mapVisualizer.Draw();

while (!simulation.Finished)
{
    Console.WriteLine(new string(Box.Horizontal, 30));

    Console.WriteLine($"{simulation.CurrentCreature} - {simulation.CurrentMoveName}:");
    simulation.Turn();
    mapVisualizer.Draw();
    
    Console.ReadKey();
}