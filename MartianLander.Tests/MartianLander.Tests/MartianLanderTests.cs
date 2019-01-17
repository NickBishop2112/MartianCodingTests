namespace MartianLander.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MartianLanderTests
    {
        [TestMethod]
        public void GivenWhenThen()
        {
            // Arrange

            // Act

            // Assert
        }

        // plateau is curiously rectangular
        // rover's position and location is represented by a combination of x and y co-ordinates
        // letter representing one of the four cardinal compass points
        // The plateau is divided up into a grid to simplify navigation

        // example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North
        // 'L', 'R' and 'M'. 'L' and 'R'. makes the rover spin 90 degrees left or right
        // 'M' means move forward one grid point, and maintain the same heading
        // Assume that the square directly North from (x, y) is (x, y+1)
        // The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are assumed to be 0,0
        // The rest of the input is information pertaining to the rovers that have been deployed
        // Each rover has two lines of input. The first line gives the rover's position, 
        // and the second line is a series of instructions telling the rover how to explore the plateau.

        // The position is made up of two integers and a letter separated by spaces, corresponding to the x and y coordinates and the rover's orientation

        // Each rover will be finished sequentially, which means that the second rover won't start to move until the first one has finished moving

        // Input:
        // 5 5
        // 1 2 N
        // LMLMLMLMM
        // 3 3 E
        // MMRMMRMRRM

        // Output:
        // 1 3 N
        // 5 1 E

    }
}
