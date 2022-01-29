using System;
using Tanaka.MarsRobot.Universe;

namespace Tanaka.MarsRobot.HumanTechnology
{
    public class Robot
    {
        private readonly Planet _planet;

        private int _currentDirection;
        private readonly string[] _directions = new string[] { "North", "East", "South", "West" };

        private int _currentPositionX;
        private int _currentPositionY;

        public int PositionX
        {
            get
            {
                return _currentPositionX;
            }
        }

        public int PositionY
        {
            get
            {
                return _currentPositionY;
            }
        }

        public string FacingDirection
        {
            get
            {
                return _directions[_currentDirection];
            }
        }

        public Robot(Planet planet, string facingDirection)
        {
            _planet = planet;
            _currentPositionX = 1;
            _currentPositionY = 1;

            PointTo(facingDirection);
        }

        #region DirectionControl
        public void PointTo(string direction)
        {
            _currentDirection = Array.IndexOf(_directions, direction);
        }

        protected void TurnLeft()
        {
            if (_currentDirection == 0)
                _currentDirection = _directions.Length - 1;
            else
                _currentDirection--;
        }

        protected void TurnRight()
        {
            if (_currentDirection == (_directions.Length - 1))
                _currentDirection = 0;
            else
                _currentDirection++;
        }
        #endregion DirectionControl

        #region MovementControl
        protected void MoveForward()
        {
            int nextPositionX = _currentPositionX;
            int nextPositionY = _currentPositionY;

            switch (_currentDirection)
            {
                case (int)Direction.NORTH:
                    nextPositionY++;
                    break;

                case (int)Direction.EAST:
                    nextPositionX++;
                    break;

                case (int)Direction.SOUTH:
                    nextPositionY--;
                    break;

                case (int)Direction.WEST:
                    nextPositionX--;
                    break;
            }

            if (!_planet.Plateau.IsOutOfBoundaries(nextPositionX, nextPositionY))
            {
                _currentPositionX = nextPositionX;
                _currentPositionY = nextPositionY;
            }
        }

        public void RunCommand(string commandSequence)
        {
            commandSequence = commandSequence.ToUpper().Replace(" ", "").Trim();

            foreach(char command in commandSequence)
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;

                    case 'R':
                        TurnRight();
                        break;

                    case 'F':
                        MoveForward();
                        break;
                }
            }
        }
        #endregion MovementControl
    }

}
