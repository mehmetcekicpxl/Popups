
using System.Threading.Tasks;

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

        private async void ToevoegenBtn_Clicked(object sender, EventArgs e)
        {
            Button newButton = new Button();
            newButton.Text = await DisplayPromptAsync("Add new Item", "wat is the name?");
            newButton.Padding = 20;
            newButton.FontSize = 20;
            newButton.CornerRadius = 10;
            newButton.BackgroundColor = GetRandomColor();

            newButton.Clicked += ChangeNameClicked;
            NamesFlexBox.Children.Add(newButton);

        }
        private async void ChangeNameClicked(object? sender,EventArgs e)
        {
            Button? clickedBtn = sender as Button;
            if (clickedBtn is not null)
            {

                bool answer = await DisplayAlert("Verwijderen", $"Wil je '{clickedBtn.Text}' verwijdere?", "ja", "nee");

                if (answer)
                {
                    NamesFlexBox.Children.Remove(clickedBtn);
                }
                else
                {
                    bool IsTheNameVeranderd = await DisplayAlert("Naam Veranderen", $"Wil je '{clickedBtn.Text}' veranderan?", "ja", "nee");
                    if (IsTheNameVeranderd)
                    {
                        clickedBtn.Text = await DisplayPromptAsync("Add new Item", "wat is the name?");

                        
                    }
                }
            }
        }
    }

}
