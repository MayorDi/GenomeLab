namespace GenomeLab;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_OnClickedToComparePage(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ComparePage());
    }
}

