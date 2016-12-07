using System;
using CocosSharp;
using Xamarin.Forms;

namespace CocosSharp_Demo
{
    public class GameView : ContentPage
    {
        // Keep the GameScene at class scope
        // so the button click events can access it:
        private GameScene _gameScene;

        public GameView()
        {
            // This is the top-level grid which will split our page in half
            var grid = new Grid { RowSpacing = 0 };
            Content = grid;
            grid.RowDefinitions = new RowDefinitionCollection
            {
                // Each half will be the same size:
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)},
                new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)}
            };

            CreateTopHalf(grid);
            CreateBottomHalf(grid);
        }

        private void CreateTopHalf(Grid grid)
        {
            // This hosts our game view. 
            var gameView = new CocosSharpView
            {
                // Notice it has the same properties as other XamarinForms Views
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                // This gets called after CocosSharp starts up:
                ViewCreated = HandleViewCreated
            };
            // We'll add it to the top half (row 0)
            grid.Children.Add(gameView, 0, 0);
        }

        private void CreateBottomHalf(Grid grid)
        {
            // We'll use a StackLayout to organize our buttons
            var stackLayout = new StackLayout();

            // The first button will move the circle to the left when it is clicked:
            var moveLeftButton = new Button
            {
                Text = "Move Circle Left"
            };
            moveLeftButton.Clicked += (sender, e) => _gameScene.MoveCircleLeft();
            stackLayout.Children.Add(moveLeftButton);

            // The second button will move the circle to the right when clicked:
            var moveCircleRight = new Button
            {
                Text = "Move Circle Right"
            };
            moveCircleRight.Clicked += (sender, e) => _gameScene.MoveCircleRight();
            stackLayout.Children.Add(moveCircleRight);

            // The stack layout will be in the bottom half (row 1):
            grid.Children.Add(stackLayout, 0, 1);
        }

        // LoadGame is called when CocosSharp is initialized. We can begin creating
        // our CocosSharp objects here:
        private void HandleViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;

            if (gameView != null)
            {
                // This sets the game "world" resolution to 100x100:
                gameView.DesignResolution = new CCSizeI(100, 100);

                // GameScene is the root of the CocosSharp rendering hierarchy:
                _gameScene = new GameScene(gameView);

                // Starts CocosSharp:
                gameView.RunWithScene(_gameScene);
            }
        }
    }
}
