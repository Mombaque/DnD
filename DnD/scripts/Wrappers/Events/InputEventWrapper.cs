using DnD.scripts.Interfaces.Godot;
using Godot;

namespace DnD.scripts.Wrappers.Events
{
    public class InputEventWrapper : IInputEventWrapper
    {
        public InputEvent InputEvent { get; set; }
        //private InputEventMouseButton _inputEventMouseButton;

        public InputEventWrapper(InputEvent inputEvent)
        {
            InputEvent = inputEvent;
        }

        public bool IsInputEventMouseButton() => InputEvent is InputEventMouseButton;
        public IMouseButtonEventWrapper GetMouseButtonEventWrapper()
        {
            var mouseEvent = (InputEventMouseButton)InputEvent;
            return new MouseButtonEventWrapper(mouseEvent.ButtonIndex, mouseEvent.Position);
        }

        public bool IsMouseButtonPressed() => ((InputEventMouseButton)InputEvent).Pressed;

    }

    public interface IInputEventWrapper
    {
        public InputEvent InputEvent { get; set; }
        IMouseButtonEventWrapper GetMouseButtonEventWrapper();
        bool IsInputEventMouseButton();
        bool IsMouseButtonPressed();
    }
}
