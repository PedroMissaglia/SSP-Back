using superSecretProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace superSecretProject.Repository
{
    public class UsersRepository : ICRUD<Users>
    {
        public void Add(Users item)
        {
            using (Context context = new Context())
            {
                context.Users.Add(item);
                context.SaveChanges();
            }
           
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        //Função auxiliar para consulta de usuário por ID
        public Users GetItem(Guid id)
        {
            using (Context context = new Context())
            {
                return context.Users.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<Users> GetItens()
        {
            throw new NotImplementedException();
        }

        public Users GetUsersEmail(string email)
        {
            using (Context context = new Context())
            {
                return context.Users.Where(x => x.Email == email).FirstOrDefault();
            }

        }
        public Users GetUserEmail(string email)
        {
            using (Context context = new Context())
            {
                return context.Users.Where(x => x.Email == email).FirstOrDefault();
            }
        }

        public Users GetUser(string email, string password)
        {
            using (Context context = new Context())
            {
                return context.Users.Where(x => x.Email == email && MD5Decrypt(x.Password) == password).FirstOrDefault();
            }
        }

        public void Update(Guid id, Users item)
        {
            var user = GetItem(id);

            using (Context context = new Context())
            {
                if (user != null)
                {

                    user.Name = item.Name;
                    user.Birthdate = item.Birthdate;
                    user.CPF = item.CPF;
                    user.Email = item.Email;
                    user.Password = MD5Encrypt(item.Password);
                    user.AutenticacaoId = item.AutenticacaoId;


                    context.Update(user);
                    context.SaveChanges();
                }
            }
        }

        public string MD5Encrypt(string password)
        {

            string PasswordHash = "P@@Sw0rd";
            string SaltKey = "S@LT&KEY";
            string VIKey = "@1B2c3D4e5F6g7H8";

            byte[] passwordTextBytes = Encoding.UTF8.GetBytes(password);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(passwordTextBytes, 0, passwordTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);

        }
        //Método para descriptografar a senha do usuário
        public string MD5Decrypt(string password)
        {
            string PasswordHash = "P@@Sw0rd";
            string SaltKey = "S@LT&KEY";
            string VIKey = "@1B2c3D4e5F6g7H8";

            byte[] cipherTextBytes = Convert.FromBase64String(password);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
