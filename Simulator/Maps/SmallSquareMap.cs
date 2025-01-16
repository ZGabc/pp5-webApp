namespace Simulator.Maps
{
    public class SmallSquareMap:Map
    {
        public int Size { get; }
        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException("Niestety rozmiar mampy musi znajdować się w przedziale 5 do 20. Proszę ponownie rozpatrz rozmiar mapy przy następnym wyborze");

            Size = size;
        }
        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
        }
        public override Point Next(Point p, Direction d)
        {
            Point sampleP = p.Next(d);
            return Exist(sampleP) ? sampleP : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point sampleP = p.NextDiagonal(d);
            return Exist(sampleP) ? sampleP : p;
        }
    }
}
