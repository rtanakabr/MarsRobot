namespace Tanaka.MarsRobot.Universe
{
    internal abstract class Terrain
    {
        protected readonly int _width;
        protected readonly int _height;

        public Terrain(int width, int height)
        {
            _width = width; 
            _height = height;
        }

        public bool IsOutOfBoundaries(int x, int y)
        {
            return x <= 0 || x > _width || y <= 0 || y > _height;
        }
    }
}
