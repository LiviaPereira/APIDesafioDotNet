using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace APIEscola.Infra.Util
{
    public static class Funcoes
    {
        public static string HashSenha(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool ValidarSenha(string senha)
        {
            
            if (senha.Length < 8)
            {
                return false;
            }

            // Senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial
            if (!Regex.IsMatch(senha, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$"))
            {
                return false;
            }

            return true;
        }
    }
}