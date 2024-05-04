using Godot;

namespace DnD.scripts.Models
{
    public partial class MapWrapper : IMapWrapper
    {
        public Map Map { get; set; }

        public MapWrapper(Map map)
        {
            Map = map;
        }

        public Node2D Spawn(Vector2 position)
        {
            var icon = (Sprite2D)Map.PackedScene.Instantiate();
            icon.GlobalPosition = position;
            
            Map.AddChild(icon);

            return icon;
        }

        public void AddChild(Node2D node) => Map.AddChild(node);

        public void ClearMapPoints()
        {
            foreach (var item in Map.MapPoints)
                item.QueueFree();

            Map.MapPoints.Clear();
        }
    }

    public interface IMapWrapper
    {
        public Map Map { get; set; }
        void AddChild(Node2D node);
        Node2D Spawn(Vector2 position);
        void ClearMapPoints();
    }

}
