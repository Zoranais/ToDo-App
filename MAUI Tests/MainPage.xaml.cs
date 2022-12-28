using MAUI_Tests.ViewModel;

namespace MAUI_Tests;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}

