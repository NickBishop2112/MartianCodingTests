namespace MartianLander
{
    using System.Collections.Generic;

    public class RoverInstruction
    {
        public RoverPosition Position { get; set; }

        public IEnumerable<Movement> Movements { get; set; }

        public string Name { get; set; }
    }
}