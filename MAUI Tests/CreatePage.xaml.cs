using MAUI_Tests.ViewModel;

namespace MAUI_Tests;

public partial class CreatePage : ContentPage
{
	public CreatePage(CreateViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}