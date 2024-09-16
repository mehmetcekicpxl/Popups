
namespace Popups
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Random rnd = new Random(); 
        private Color GetRandomColor()
        {
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
    }

}
