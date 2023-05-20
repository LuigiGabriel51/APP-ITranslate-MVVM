using appMVVM.ViewModel;

namespace appMVVM.View;

public partial class Page1 : ContentPage
{
    public Page1()
    {
        InitializeComponent();
        VMtraducao viewModel = new VMtraducao();
        BindingContext = viewModel;
    }

}