using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.scripts.Interfaces.Godot
{
    public class MouseButtonEventWrapper : IMouseButtonEventWrapper
    {
        public MouseButton MouseButton { get; set; }
        public Vector2 Position { get; set; }

        public MouseButtonEventWrapper(MouseButton mouseButton, Vector2 position)
        {
            MouseButton = mouseButton;
            Position = position;
        }
    }

    public interface IMouseButtonEventWrapper
    {
        public MouseButton MouseButton { get; set; }
        public Vector2 Position { get; set; }
    }
}
