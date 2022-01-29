namespace Tanaka.MarsRobot.Universe
{
    public class Planet
    {
        internal readonly Terrain Plateau;

        public Planet(int width, int height)
        {
            Plateau = new Plateau(width, height);            
        }
    }
}
