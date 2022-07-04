using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cifrar
    {

        public string CifrarContraseña (string contraseña)
        {
            string hash = "SistemasDeInformaciónXYZ123*";
            byte [] data = UTF8Encoding.UTF8.GetBytes(contraseña);
            MD5 md5 = MD5.Create();
            TripleDES triple = TripleDES.Create();
            triple.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            triple.Mode = CipherMode.ECB;

            ICryptoTransform crypto = triple.CreateEncryptor();
            byte[] resultado = crypto.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(resultado);
        }

    }
}
