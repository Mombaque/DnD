using Godot;
using System;

public partial class Map : Node2D
{
    public Vector2? FirstNode { get; set; } = null;
    public Vector2? SecondNode { get; set; } = null;
    [Export]
    public PackedScene PackedScene { get; set; }
    private bool _allNodesClicked => 
        FirstNode != null && SecondNode != null;

    public override void _Ready()
	{
        FirstNode = null;
        SecondNode = null;

        
    }

	public override void _Process(double delta)
	{

	}

	//public override void _Draw()
	//{
        //if (!_allNodesClicked)
        //    return;

        //DrawLine(
        //    FirstNode.Value,
        //    SecondNode.Value,
        //    new Color(1, 0, 0),
        //    5);

        //FirstNode = null;
        //SecondNode = null;
    //}

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
        {
            HandleLeftMouseButton(mouseButton);
        }
    }

    public void HandleLeftMouseButton(InputEventMouseButton mouseButton)
    {
        if (mouseButton.ButtonIndex != MouseButton.Left)
            return;

        var clickPosition = mouseButton.GlobalPosition;

        FirstNode = FirstNode == null ? clickPosition : FirstNode;

        SecondNode = FirstNode != clickPosition && SecondNode == null
            ? clickPosition
            : SecondNode;

        GD.Print("First: " + FirstNode);
        GD.Print("Second: " + SecondNode);

        if (!_allNodesClicked)
            return;

        AddNode(FirstNode.Value);
        AddNode(SecondNode.Value);

        ResetNodesPositions();
    }

    private void AddNode(Vector2 position)
    {
        var icon = (Sprite2D)PackedScene.Instantiate();
        icon.GlobalPosition = position;
        AddChild(icon);
    }

    private void ResetNodesPositions()
    {
        FirstNode = null;
        SecondNode = null;
    }
}
