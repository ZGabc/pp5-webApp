using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private List<Creature>?[,] _fields;

    /// <summary>
    /// SmallMap constructor. Map size in both directions needs to be in range [5,20]. 
    /// </summary>
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Map size cannot be larger than 20"); //wyjątek -> wymiar mapy nie pasuje do założeń
        }
        else if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Map size cannot be larger than 20"); //wyjątek -> wymiar mapy nie pasuje do założeń
        }

        _fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point point)
    {
        if (!Exist(point)) // sprawdzam czy punkt nalezy do mapy
        {
            throw new ArgumentException("Point needs to belong to the map", nameof(point));
        }
        else // punkt należy do mapy
        {
            if (_fields[point.X, point.Y] != null && _fields[point.X, point.Y].Count != 0)
            {
                _fields[point.X, point.Y].Add(creature); // Lista creatuerów w tym punkcie już istnieje
            }
            else
            {
                var lista = new List<Creature> { creature }; // Lista w tym punkcie jeszcze nie istnieje - inicjuję listę.
                _fields[point.X, point.Y] = lista;
            }
            creature.InitMapAndPosition(this, point, true);
        }
    }

    public override void Remove(Creature creature, Point point)
    {
        if (_fields[point.X, point.Y].Contains(creature)) // Jest stwór o podanej nazwie na mapie
        {
            _fields[point.X, point.Y].Remove(creature);
            creature.RemoveFromMap();
        }
        else // W podanym punkcie nie ma stwora o podanej nazwie
        {
            throw new ArgumentException("In the indicated point there is no creature with given name", nameof(creature));
        }
    }

    public override string At(Point point)
    {
        if (this.Exist(point) == false)
        {
            return $"Point {point} does not belong to the map.";
        }
        else
        {
            var listOfCreaturesInPoint = _fields[point.X, point.Y];
            if (listOfCreaturesInPoint != null && listOfCreaturesInPoint.Count != 0)
            {
                var listaStworow = new String("");
                foreach (Creature creature in listOfCreaturesInPoint)
                {
                    var creatureName = creature.Name;
                    listaStworow += creatureName + ", ";
                }

                return $"The creatures in point {point} are as follows: {listaStworow.Substring(0, listaStworow.Length - 2)}";
            }
            else
            {
                return $"There is no creature in the indicated point {point}.";
            }
        }
    }

    public override string At(int x, int y)
    {
        var point = new Point(x, y);
        return this.At(point);
    }

    public override List<Creature> ListOfCreaturesAt(int x, int y) // Możnaby zmienić istniejące metody At aby zwracały listę, ale nie chcę rezygnować z już istniejących.
    {
        var point = new Point(x, y);
        if (this.Exist(point) == false)
        {
            return new List<Creature> { };
        }
        else
        {
            var listOfCreaturesInPoint = _fields[x, y];
            if (listOfCreaturesInPoint != null && listOfCreaturesInPoint.Count != 0)
            {
                return listOfCreaturesInPoint;
            }
            else
            {
                return new List<Creature> { };
            }
        }
    }
}
