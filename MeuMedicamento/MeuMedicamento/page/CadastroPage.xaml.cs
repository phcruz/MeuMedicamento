using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeuMedicamento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroPage : ContentPage
	{
		public CadastroPage ()
		{
			InitializeComponent ();
		}

        async void OnButtonClicked_Cadastrar(object sender, EventArgs args)
        {
            if (!String.IsNullOrEmpty(nomeEntry.Text)
                && !String.IsNullOrEmpty(emailEntry.Text) 
                && !String.IsNullOrEmpty(senhaEntry.Text)
                && !String.IsNullOrEmpty(senhaConfirmeEntry.Text)) {

                if (Constants.IsEmailValido(emailEntry.Text))
                {
                    if (Constants.ValidarSenha(senhaEntry.Text))
                    {
                        if (senhaEntry.Text.Equals(senhaConfirmeEntry.Text))
                        {
                            //verificar se o email nao pertence a outro usuario
                            Usuario usuario = await App.DataBase.buscaUsuarioEmail(emailEntry.Text);

                            if (usuario == null) {
                                Usuario user = new Usuario();
                                user.Nome = nomeEntry.Text;
                                user.Email = emailEntry.Text;
                                user.Senha = senhaEntry.Text;

                                //grava no banco de dados local
                                await App.DataBase.SaveItemAsync(user);

                                //realiza o cadastro e redireciona para a pagina principal logado
                                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                                if (rootPage != null)
                                {
                                    App.IsUserLoggedIn = true;
                                    Navigation.InsertPageBefore(new TabPage(), Navigation.NavigationStack.First());
                                    await Navigation.PopToRootAsync();
                                }
                            }
                            else
                            {
                                await DisplayAlert(Constants.ERRO, Constants.EMAIL_JA_CADASTRADO, Constants.OK);
                            }
                        }
                        else
                        {
                            await DisplayAlert(Constants.ERRO, Constants.SENHAS_NAO_CONFEREM, Constants.OK);
                        }
                    }
                    else
                    {
                        await DisplayAlert(Constants.ERRO, Constants.A_SENHA_DEVE_CONTER, Constants.OK);
                    }
                }
                else
                {
                    await DisplayAlert(Constants.ERRO, Constants.EMAIL_INVALIDO, Constants.OK);
                }
            }
            else
            {
                await DisplayAlert(Constants.ERRO, Constants.PREENCHA_TODOS_OS_CAMPOS_PARA_SE_CADASTRAR, Constants.OK);
            }
        }
    }
}