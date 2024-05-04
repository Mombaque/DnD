//using DnD.scripts.Interfaces.Godot;
//using DnD.scripts.Wrappers.Map;
//using Godot;
//using Moq;
//using System.Collections.Generic;
//using Xunit;

//namespace DnD.UnitTests
//{
//    public class MapWrapperTests
//    {
//        private readonly MapWrapper _mapWrapper;
//        private readonly Mock<IMouseButtonEventWrapper> _mouseEvent;

//        public MapWrapperTests()
//        {
//            _mapWrapper = new MapWrapper();
//            _mouseEvent = new Mock<IMouseButtonEventWrapper>();
//        }

//        [Fact]
//        public void ShouldSetJustFirstNode()
//        {
//            var clickedPosition = new Vector2(5, 5);
//            _mouseEvent.SetupGet(x => x.Position).Returns(clickedPosition);

//            var result = _mapWrapper.HandleLeftMouseButton(
//                null,
//                null,
//                _mouseEvent.Object);

//            var expected = new Dictionary<int, Vector2?>()
//            {
//                {0, clickedPosition},
//                {1, null},
//            };

//            Assert.Equal(expected, result);
//        }

//        [Fact]
//        public void ShouldSetBothNodes()
//        {
//            var firstNode = new Vector2(10, 10);
//            var clickedPosition = new Vector2(5, 5);

//            _mouseEvent.SetupGet(x => x.Position).Returns(clickedPosition);

//            var result = _mapWrapper.HandleLeftMouseButton(
//                firstNode,
//                null,
//                _mouseEvent.Object);

//            var expected = new Dictionary<int, Vector2?>()
//            {
//                {0, firstNode},
//                {1, clickedPosition},
//            };

//            Assert.Equal(expected, result);
//        }
//    }
//}
