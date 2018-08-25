using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuMedicamento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sair : ContentPage
	{
		public Sair ()
		{
			InitializeComponent ();
		}

        async void OnButtonClicked_Sair(object sender, EventArgs args)
        {
            App.IsUserLoggedIn = false;
        
            var rootPage = Navigation.NavigationStack.FirstOrDefault();
            if (rootPage != null)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                await Navigation.PopToRootAsync();
            }
        }
    }
}