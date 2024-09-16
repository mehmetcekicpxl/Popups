
namespace Popups
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            string student = await DisplayPromptAsync("Toevoegen", "Naam:");

            if (!string.IsNullOrWhiteSpace(student))
            {
                Button btn = new Button
                {
                    Text = student,
                    FontSize = 20,
                    Padding=20,
                    CornerRadius=10,
                    BackgroundColor = GetRandomColor(),
                };
                btn.Clicked += Member_ClickedAsync;
                flexLayout.Children.Add(btn);
            }
        }


        private async void Member_ClickedAsync(object? sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Verwijderen", $"Bent u zeker dat u {((Button)sender).Text} wil verwijderen?", "Ja", "Nee");

            if (answer)
                flexLayout.Children.Remove((Button)sender);
        }

        private Random rnd = new Random(); 
        private Color GetRandomColor()
        {
            return Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
    }

}
