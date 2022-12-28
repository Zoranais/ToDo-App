using MAUI_Tests.ViewModel;

namespace MAUI_Tests;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}