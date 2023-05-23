using appMVVM.ViewModel;
using Microsoft.Maui.Graphics.Text;

namespace appMVVM.View;

public partial class Page1 : ContentPage
{
    public Page1()
    {
        InitializeComponent();
        VMtraducao viewModel = new VMtraducao();
        BindingContext = viewModel;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        if(bt.TextColor == Colors.White) {
            bt.TextColor = Colors.Yellow;
            await Task.Delay(700);
            bt.TextColor = Colors.White;
        }
        else
        {
            bt.TextColor = Colors.Yellow;
            await Task.Delay(700);
            bt.TextColor = Colors.Black;
        }
        
    }
}