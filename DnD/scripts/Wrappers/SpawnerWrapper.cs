using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.scripts.Wrappers
{
    public class SpawnerWrapper : ISpawnerWrapper
    {
        public Node2D Parent { get; set; }

        public SpawnerWrapper(Node2D parent)
        {
            Parent = parent;
        }

        public void AddChild(Node2D node) => Parent.AddChild(node);
    }

    public interface ISpawnerWrapper
    {
        public Node2D Parent { get; set; }

        void AddChild(Node2D node);
    }
}
