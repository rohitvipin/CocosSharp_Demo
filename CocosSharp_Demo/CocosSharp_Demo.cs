using Xamarin.Forms;

namespace CocosSharp_Demo
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new NavigationPage(new ContentPage
            //{
            //    Title = "CocosSharp_Demo",
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //});

            MainPage = new GameView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
