using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ChatAppCoreMVC.Services
{
    public class HashAlgorithm
    {
        private readonly string Salt;

        public HashAlgorithm()
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.secret.json", optional: true)
              .Build();
            Salt = config.GetSection("Security").GetValue<string>("Salt");
        }

        public string GetHash(string input)
        {
            var hashAlgorithm = SHA256.Create();
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input + Salt));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
