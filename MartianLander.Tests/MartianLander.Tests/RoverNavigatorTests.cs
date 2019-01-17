namespace MartianLander.Tests
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RoverNavigatorTests
    {       
        [TestMethod]
        public void GivenNavigateWhenRoverMovesThenRoverMovedOverPlateauCorrectly()
        {
            // Arrange
            var roverNavigator = new RoverNavigator();

            // Act
            var roversPositions = 
                roverNavigator.Navigate(
                    new PlateauCoordinates
                    {
                        X = 5,
                        Y = 5
                    },
                    new List<RoverInstruction>
                    {
                        new RoverInstruction
                        {
                            Position = new RoverPosition {
                                Coordinates = new PlateauCoordinates { X = 1, Y = 2}, CardinalCompassPoint = CardinalCompassPoint.North  },
                            Movements =
                                new List<Movement>
                                {
                                    Movement.LeftSpin,
                                    Movement.Move,
                                    Movement.LeftSpin,
                                    Movement.Move,
                                    Movement.LeftSpin,
                                    Movement.Move,
                                    Movement.LeftSpin,
                                    Movement.Move,
                                    Movement.Move,
                                },
                            Name = "Rover 1"
                         },
                        new RoverInstruction
                        {
                            Position = new RoverPosition {
                                Coordinates = new PlateauCoordinates { X = 3, Y = 3 }, CardinalCompassPoint = CardinalCompassPoint.East  },
                            Movements =
                                new List<Movement>
                                {
                                    Movement.Move,
                                    Movement.Move,
                                    Movement.RightSpin,
                                    Movement.Move,
                                    Movement.Move,
                                    Movement.RightSpin,
                                    Movement.Move,
                                    Movement.RightSpin,
                                    Movement.RightSpin,
                                    Movement.Move,
                                },
                            Name = "Rover 2"
                        }
                    });

            // Assert
            roverNavigator.Plateau.Should().BeEquivalentTo(
               new Plateau
               {
                   LowerLeftCoordinates = new PlateauCoordinates { X = 0, Y = 0 },
                   UpperRightCoordinates = new PlateauCoordinates { X = 5, Y = 5 }
               });

            roversPositions.Should().BeEquivalentTo(
                new List<IEnumerable<RoverPosition>>
                {
                    new List<RoverPosition>
                    {
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 1, Y = 2}, CardinalCompassPoint = CardinalCompassPoint.North },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 1, Y = 2}, CardinalCompassPoint = CardinalCompassPoint.West },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 0, Y = 2}, CardinalCompassPoint = CardinalCompassPoint.West },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 0, Y = 2}, CardinalCompassPoint = CardinalCompassPoint.South },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 0, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.South },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 0, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.East },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 1, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.East },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 1, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.North },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 1, Y = 2}, CardinalCompassPoint = CardinalCompassPoint.North },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 1, Y = 3}, CardinalCompassPoint = CardinalCompassPoint.North },
                    },
                    new List<RoverPosition>
                    {
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 3, Y = 3}, CardinalCompassPoint = CardinalCompassPoint.East },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 4, Y = 3}, CardinalCompassPoint = CardinalCompassPoint.East },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 5, Y = 3}, CardinalCompassPoint = CardinalCompassPoint.East },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 5, Y = 3}, CardinalCompassPoint = CardinalCompassPoint.South },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 5, Y = 2}, CardinalCompassPoint = CardinalCompassPoint.South },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 5, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.South },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 5, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.West },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 4, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.West },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 4, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.North },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 4, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.East },
                        new RoverPosition { Coordinates = new PlateauCoordinates { X = 5, Y = 1}, CardinalCompassPoint = CardinalCompassPoint.East },
                    },
                });
        }
    }
}
