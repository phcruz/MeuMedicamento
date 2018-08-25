using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MeuMedicamento
{
    class Constants
    {
        //public static string RestUrl = "http://developer.xamarin.com:8081/api/todoitems/{0}";
        public static string RestUrlNome = "http://mobile-aceite.tcu.gov.br/mapa-da-saude/rest/remedios?produto={0}";
        public static string RestUrlCodigoEan = "http://mobile-aceite.tcu.gov.br/mapa-da-saude/rest/remedios?codBarraEan={0}";

        //Mensagens
        public static string OK = "OK";
        public static string ERRO = "Erro";
        public static string USUARIO_NAO_CADASTRADO = "Usuário não cadastrado.";
        public static string LOGIN_FALHOU = "Login falhou ";
        public static string USUARIO_SENHA_NAO_CONFEREM = "Usuario/senha não conferem";
        public static string EMAIL_INVALIDO = "Email inválido";
        public static string PREENCHA_CAMPOS_EMAIL_SENHA = "Preencha os campos de email e senha.";
        public static string NENHUM_MEDICAMENTO_ENCONTRADO_NOME = "Nenhum medicamento encontrado com este nome.";
        public static string INFORME_NOME_MEDICAMENTO = "Informe o nome do medicamento para realizar a consulta.";
        public static string NENHUM_MEDICAMENTO_ENCONTRADO_CODIGO_EAN = "Nenhum medicamento encontrado com este codigo de barras.";
        public static string INFORME_CODIGO_EAN_MEDICAMENTO = "Informe o codigo de barras do medicamento para realizar a consulta.";
        public static string EMAIL_JA_CADASTRADO = "E-mail já cadastrado para outro usuário.";
        public static string SENHAS_NAO_CONFEREM = "Senhas não conferem";
        public static string A_SENHA_DEVE_CONTER = "A senha deve conter no minimo 6 caracteres com letras e numeros.";
        public static string PREENCHA_TODOS_OS_CAMPOS_PARA_SE_CADASTRAR = "Preencha todos os campos para se cadastrar";
        
        //Regex
        public static string REGEX_SENHA = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,10})$";


        //Metodos de verificacao
        public static bool IsEmailValido(string enderecoEmail)
        {
            try
            {
                MailAddress m = new MailAddress(enderecoEmail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool ValidarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha) || senha.Length < 6)
            {
                return false;
            }

            if (!Regex.IsMatch(senha, Constants.REGEX_SENHA))
            {
                return false;
            }

            return true;
        }
    }
}
