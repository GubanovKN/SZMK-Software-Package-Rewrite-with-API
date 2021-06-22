using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZMK.Desktop.Services.Crypto.Interfaces
{
    interface ICryptoService
    {
        string Encrypt(string Text, string Salt);
        string GetSalt(int Count);
    }
}
