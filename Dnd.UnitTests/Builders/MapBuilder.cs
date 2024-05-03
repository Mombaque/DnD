namespace Godot.UnitTests.Builders
{
    public partial class MapBuilder : Map
    {
        public MapBuilder()
        {
            FirstNode = null;
            SecondNode = null;
        }

        public Map WithFirstNode(Vector2 position)
        {
            FirstNode = position;
            return this;
        }

        public Map WithSecondNode(Vector2 position)
        {
            SecondNode = position;
            return this;
        }
    }
}
