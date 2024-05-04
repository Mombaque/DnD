using DnD.scripts.Interfaces.Godot;
using DnD.scripts.Models;
using DnD.scripts.Wrappers.Events;
using Godot;
using System;
using System.Collections.Generic;

namespace DnD.scripts;

public partial class Map : Node2D
{
    [Export]
    public PackedScene PackedScene { get; set; }
    public Vector2? FirstNode { get; set; } = null;
    public Vector2? SecondNode { get; set; } = null;
    public List<Node2D> MapPoints { get; set; } = new List<Node2D>();


    public bool AllNodesClicked => 
        FirstNode != null && SecondNode != null;

    public override void _Ready()
	{

    }

	public override void _Process(double delta)
	{

	}

    public override void _Input(InputEvent inputEvent)
    {
        var inputWrapper = new InputEventWrapper(inputEvent);
        HandleInput(new MapWrapper(this), inputWrapper);
    }

    public static void HandleInput(IMapWrapper mapWrapper, IInputEventWrapper eventWrapper)
    {
        if (eventWrapper.IsInputEventMouseButton() && eventWrapper.IsMouseButtonPressed())
            HandleMouseButtonEvent(mapWrapper, eventWrapper.GetMouseButtonEventWrapper());
    }

    private static void HandleMouseButtonEvent(
        IMapWrapper mapWrapper,
        IMouseButtonEventWrapper mouseButtonEventWrapper)
    {
        if (mouseButtonEventWrapper.MouseButton == MouseButton.Right)
        {
            mapWrapper.ClearMapPoints();
            return;
        }        

        if (mouseButtonEventWrapper.MouseButton == MouseButton.Left)
        {
            var clickedPosition = mouseButtonEventWrapper.Position;
            mapWrapper.Spawn(clickedPosition);
        }
    }
}
