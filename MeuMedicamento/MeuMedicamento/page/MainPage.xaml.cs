using System;
using Xamarin.Forms;

namespace MeuMedicamento
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked_Cadastro(object sender, EventArgs args)
        {
            var cadastroPage = new CadastroPage();
            await Navigation.PushAsync(cadastroPage);
        }

        async void OnButtonClicked_Login(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(emailEntry.Text) && !String.IsNullOrEmpty(senhaEntry.Text))
            {
                if (Constants.IsEmailValido(emailEntry.Text))
                {
                    if (Constants.ValidarSenha(senhaEntry.Text))
                    {
                        Usuario usuario = await App.DataBase.buscaUsuarioEmail(emailEntry.Text);

                        if (usuario == null) {
                            await DisplayAlert(Constants.ERRO, Constants.USUARIO_NAO_CADASTRADO, Constants.OK);
                        }
                        else {
                            var user = new Usuario
                            {
                                Email = emailEntry.Text,
                                Senha = senhaEntry.Text
                            };



                            var isValid = VerificaCredenciais(user, usuario);
                            if (isValid)
                            {
                                App.IsUserLoggedIn = true;
                                Navigation.InsertPageBefore(new TabPage(), this);
                                await Navigation.PopAsync();
                            }
                            else
                            {
                                await DisplayAlert(Constants.LOGIN_FALHOU, Constants.USUARIO_SENHA_NAO_CONFEREM, Constants.OK);
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert(Constants.LOGIN_FALHOU, Constants.USUARIO_SENHA_NAO_CONFEREM, Constants.OK);
                    }
                }
                else
                {
                    await DisplayAlert(Constants.ERRO, Constants.EMAIL_INVALIDO, Constants.OK);
                }
            }
            else
            {
                await DisplayAlert(Constants.ERRO, Constants.PREENCHA_CAMPOS_EMAIL_SENHA, Constants.OK);
            }
        }

        bool VerificaCredenciais(Usuario user, Usuario usuario)
        {
            //return user.Email == "paulo@gmail.com" && user.Senha == "123qwe";
            return user.Email == usuario.Email && user.Senha == usuario.Senha;
        }
    }
}
