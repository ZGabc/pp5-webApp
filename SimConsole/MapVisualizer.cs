using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private Map _map { get; }

    private string[] _mapDataStr;

    public MapVisualizer(Map map)
    {
        _map = map;
        _mapDataStr = new string[_map.SizeY];
    }

    private string CreateEdge(char start, char horizontal, char mid, char end, int width)
    {
        var edge = new StringBuilder();
        edge.Append(start);

        for (var i = 0; i < width; i++)
        {
            edge.Append(horizontal);
            edge.Append(mid);
        }

        edge.Append(horizontal);
        edge.Append(end);

        return edge.ToString();
    }

    private void InitDataRows()
    {
        for (var y = 0; y < _map.SizeY; y++)
        {
            _mapDataStr[y] = Box.Vertical.ToString();

            for (var x = 0; x < _map.SizeX; x++)
            {
                var creatures = _map.At(x, y);

                if (creatures is null || creatures.Count == 0)
                    _mapDataStr[y] += " ";
                else if (creatures.Count == 1)
                    _mapDataStr[y] += creatures[0] is Orc ? 'O' : 'E';
                else
                    _mapDataStr[y] += 'X';

                _mapDataStr[y] += Box.Vertical;
            }
        }
    }

    public void Draw()
    {
        var width = _map.SizeX - 1;

        var top = CreateEdge(Box.TopLeft, Box.Horizontal, Box.TopMid, Box.TopRight, width);
        var middle = CreateEdge(Box.MidLeft, Box.Horizontal, Box.Cross, Box.MidRight, width);
        var bottom = CreateEdge(Box.BottomLeft, Box.Horizontal, Box.BottomMid, Box.BottomRight, width);

        InitDataRows();
        List<string> consoleOutput = [top];

        for (var j = _map.SizeY - 1; j > 0; j--)
        {
            consoleOutput.Add(_mapDataStr[j]);
            consoleOutput.Add(middle);
        }

        consoleOutput.Add(_mapDataStr[0]);
        consoleOutput.Add(bottom);

        foreach (var line in consoleOutput)
        {
            Console.WriteLine(line);
        }
    }
}
