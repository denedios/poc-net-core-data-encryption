using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PocNetCoreDataEncryption.DAL.ValueConverters
{
    public class EncryptedConverter : ValueConverter<string, string>
    {
        public EncryptedConverter(ConverterMappingHints mappingHints = default)
            : base(EncryptExpr, DecryptExpr, mappingHints)
        { }

        private static readonly Expression<Func<string, string>> DecryptExpr = x => Decrypt(x);

        private static readonly Expression<Func<string, string>> EncryptExpr = x => Encrypt(x);



        private static string Encrypt(string input)
        {
            // todo: use always encrypted cryptography algorithm to encrypt here
            return new string(input.Reverse().ToArray());
        }

        private static string Decrypt(string input)
        {
            // todo: use always encrypted cryptography algorithm to decrypt here
            return new string(input.Reverse().ToArray());
        }
    }
}
