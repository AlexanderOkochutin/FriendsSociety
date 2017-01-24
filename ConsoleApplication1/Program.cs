using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoService;
using ICryptoService;
using ORM;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SocialNetworkContext context = new SocialNetworkContext(new PasswordService());
            var test = context.Users;
        }
    }
}
