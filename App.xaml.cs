using Microsoft.Maui.ApplicationModel;

namespace appMVVM;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
    

