using CocosSharp;

namespace CocosSharp_Demo
{
    public class GameScene : CCScene
    {
        private readonly CCDrawNode _circle;

        public GameScene(CCGameView gameView) : base(gameView)
        {
            var layer = new CCLayer();
            AddLayer(layer);

            _circle = new CCDrawNode();
            layer.AddChild(_circle);

            _circle.DrawCircle(
                // The center to use when drawing the circle,
                // relative to the CCDrawNode:
                new CCPoint(0, 0),
                radius: 15,
                color: CCColor4B.White);

            _circle.PositionX = 20;
            _circle.PositionY = 50;
        }

        public void MoveCircleLeft() => _circle.PositionX -= 10;

        public void MoveCircleRight() => _circle.PositionX += 10;
    }
}
