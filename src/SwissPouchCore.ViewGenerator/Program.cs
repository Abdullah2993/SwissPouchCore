using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SwissPouchCore.Controllers;

namespace SwissPouchCore.ViewGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var html = BindingGenerator.Generate(typeof (UtilitiesController));
            var layout = File.ReadAllText(@"layout.txt");
            var rendered=layout.Replace("@RenderBody()", html).Replace("@Title()","Utilities");
            File.WriteAllText("Index.html",rendered);

            html = BindingGenerator.Generate(typeof(CryptoController));
            layout = File.ReadAllText(@"layout.txt");
            rendered = layout.Replace("@RenderBody()", html).Replace("@Title()", "Crypto");
            File.WriteAllText("crypto.html", rendered);
        }
    }
}
