using dbTest2.View;

namespace dbTest2;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

		pagedb.Clicked += (sender, obj) => {
			Navigation.PushAsync(new page1()); };
		
    }
	

	
}


