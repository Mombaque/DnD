using DnD.scripts;
using DnD.scripts.Interfaces.Godot;
using DnD.scripts.Models;
using DnD.scripts.Wrappers.Events;
using Godot;
using Moq;
using Xunit;

namespace DnD.UnitTests
{
    public class MapTests
    {
        private readonly Mock<IMapWrapper> _mapWrapper;
        private readonly Mock<IInputEventWrapper> _eventWrapper;

        public MapTests()
        {
            _mapWrapper = new Mock<IMapWrapper>();
            _eventWrapper = new Mock<IInputEventWrapper>();
        }

        [Fact]
        public void ShouldClearMapWhenRightMouseButtonIsPressed()
        {
            _eventWrapper.Setup(x => x.IsInputEventMouseButton()).Returns(true);
            _eventWrapper.Setup(x => x.IsMouseButtonPressed()).Returns(true);

            var mouseButtonEventWrapper = new MouseButtonEventWrapper(MouseButton.Right, new Vector2());
            _eventWrapper.Setup(x => x.GetMouseButtonEventWrapper()).Returns(mouseButtonEventWrapper);

            Map.HandleInput(_mapWrapper.Object, _eventWrapper.Object);

            _mapWrapper.Verify(x => x.ClearMapPoints(), Times.Once);
            _mapWrapper.Verify(x => x.Spawn(It.IsAny<Vector2>()), Times.Never);
        }

        [Fact]
        public void ShouldClearMapWhenLeftMouseButtonIsPressed()
        {
            _eventWrapper.Setup(x => x.IsInputEventMouseButton()).Returns(true);
            _eventWrapper.Setup(x => x.IsMouseButtonPressed()).Returns(true);

            var mouseButtonEventWrapper = new MouseButtonEventWrapper(MouseButton.Left, new Vector2(5, 4));
            _eventWrapper.Setup(x => x.GetMouseButtonEventWrapper()).Returns(mouseButtonEventWrapper);

            Map.HandleInput(_mapWrapper.Object, _eventWrapper.Object);

            _mapWrapper.Verify(x => x.ClearMapPoints(), Times.Never);
            _mapWrapper.Verify(x => x.Spawn(mouseButtonEventWrapper.Position), Times.Once);
        }

        //[Fact]
        //public void ShouldGetMousePositionResult()
        //{
        //    var map = new Map();
        //    var clickedPosition = new Vector2(5, 5);

        //    _mouseEvent.SetupGet(x => x.MouseButton).Returns(MouseButton.Left);
        //    _mouseEvent.SetupGet(x => x.Position).Returns(clickedPosition);

        //    var mockResult = new System.Collections.Generic.Dictionary<int, Vector2?>()
        //        {
        //            { 0, clickedPosition },
        //            { 1, null }
        //        };

        //    _mapWrapper.Setup(x => 
        //        x.HandleLeftMouseButton(
        //            It.IsAny<Vector2?>(), 
        //            It.IsAny<Vector2?>(), 
        //            It.IsAny<IMouseButtonEventWrapper>()))
        //        .Returns(mockResult);

        //    var result = Map.HandleLeftMouseButton(
        //        _mapWrapper.Object,
        //        null,
        //        null,
        //        _mouseEvent.Object);

        //    Assert.Equal(result, mockResult);
        //}

    }
}