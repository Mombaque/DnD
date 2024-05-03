using Godot.UnitTests.Builders;
using Xunit;

namespace Godot.UnitTests
{
    public class MapTests
    {
        public MapTests()
        {
        }

        [Fact]
        public void ShouldSetFirstNodeWhenHandlingLeftMouseButton()
        {
            var map = new Map();
            var @event = new InputEventMouseButton();

            map.HandleLeftMouseButton(@event);

            Assert.Equal(map.FirstNode, @event.GlobalPosition);
            Assert.Null(map.SecondNode);
        }
    }
}