namespace MartianLander
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoverNavigator
    {
        private readonly IDictionary<ValueTuple<Movement, CardinalCompassPoint>, ValueTuple<int, int, CardinalCompassPoint?>> cardinalCompassPointMovements;

        public RoverNavigator()
        {
            this.Plateau = new Plateau
            {
                LowerLeftCoordinates =
                    new PlateauCoordinates { X = 0, Y = 0 }
            };

            this.cardinalCompassPointMovements = 
                new Dictionary<ValueTuple<Movement, CardinalCompassPoint>, ValueTuple<int, int, CardinalCompassPoint?>>
                {
                    [(Movement.LeftSpin, CardinalCompassPoint.North)] = (0 ,0, CardinalCompassPoint.West), 
                    [(Movement.LeftSpin, CardinalCompassPoint.West)] = (0, 0, CardinalCompassPoint.South),
                    [(Movement.LeftSpin, CardinalCompassPoint.South)] = (0, 0, CardinalCompassPoint.East),
                    [(Movement.LeftSpin, CardinalCompassPoint.East)] = (0, 0, CardinalCompassPoint.North),
                    [(Movement.Move, CardinalCompassPoint.North)] = (0, 1, null),
                    [(Movement.Move, CardinalCompassPoint.West)] = (-1, 0, null),
                    [(Movement.Move, CardinalCompassPoint.South)] = (0, -1, null),
                    [(Movement.Move, CardinalCompassPoint.East)] = (1, 0, null),
                    [(Movement.RightSpin, CardinalCompassPoint.North)] = (0, 0, CardinalCompassPoint.East),
                    [(Movement.RightSpin, CardinalCompassPoint.West)] = (0, 0, CardinalCompassPoint.North),
                    [(Movement.RightSpin, CardinalCompassPoint.South)] = (0, 0, CardinalCompassPoint.West),
                    [(Movement.RightSpin, CardinalCompassPoint.East)] = (0, 0, CardinalCompassPoint.South),
                };
        }

        public Plateau Plateau { get; private set; }

        public IEnumerable<IEnumerable<RoverPosition>> Navigate(
            PlateauCoordinates plateauCoordinates, 
            IEnumerable<RoverInstruction> roverInstructions)
        {
            this.Plateau.UpperRightCoordinates = plateauCoordinates;

            var recordedRoversPosition = new List<IEnumerable<RoverPosition>>();

            foreach (var roverInstruction in roverInstructions)
            {
                var lastPosition = roverInstruction.Position;

                var roverPositions = new List<RoverPosition>();
                roverPositions.Add(lastPosition);

                foreach (var movement in roverInstruction.Movements)
                {
                    if (this.cardinalCompassPointMovements.ContainsKey((movement, lastPosition.CardinalCompassPoint)))
                    {
                        (int X, int Y, CardinalCompassPoint? cardinalCompassPoint) cardinalCompassPoint = this.cardinalCompassPointMovements[(movement, lastPosition.CardinalCompassPoint)];

                        var newPosition = new RoverPosition
                        {
                            Coordinates =
                                new PlateauCoordinates
                                {
                                    X = lastPosition.Coordinates.X + cardinalCompassPoint.X,
                                    Y = lastPosition.Coordinates.Y + cardinalCompassPoint.Y
                                },
                            CardinalCompassPoint = cardinalCompassPoint.cardinalCompassPoint ?? lastPosition.CardinalCompassPoint
                        };

                        lastPosition = newPosition;
                        roverPositions.Add(newPosition);                        
                    }
                }

                recordedRoversPosition.Add(roverPositions);
            }

            return recordedRoversPosition;
        }       
    }
}