using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNet.Mvc;
using SwissPouchCore.Attributes;

namespace SwissPouchCore.ViewGenerator
{
    public static class BindingGenerator
    {
        public static string Generate(Type type)
        {
            var stringBuilder=new StringBuilder();
            foreach (var methodInfo in type.GetMethods())
            {
                var getAttr = methodInfo.GetCustomAttribute<HttpGetAttribute>();
                var postAttr = methodInfo.GetCustomAttribute<HttpPostAttribute>();
                var owsvAttr = methodInfo.GetCustomAttribute<OwsvAttribute>();
                var twsvAttr = methodInfo.GetCustomAttribute<TwsvAttribute>();

                var method = getAttr != null ? "GET" : postAttr != null ? "POST" : null;

                if (method == null)
                {
                    continue;
                }

                if (owsvAttr != null)
                {
                    var link = $"api/{type.Name.Replace("Controller", "")}/{methodInfo.Name}";
                    var str =
                        $"<owsv params= \"title: '{owsvAttr.Title}', buttonLabel: '{owsvAttr.ButtonLabel}', link: '{link}', placeHolder: '{owsvAttr.PlaceHolder}' ,method: '{method}'\" ></owsv>";

                    stringBuilder.AppendLine(str);
                }
                else if (twsvAttr != null)
                {
                    var link = $"api/{type.Name.Replace("Controller", "")}/{methodInfo.Name}";
                    var str =
                        $"<twsv params= \"title: '{twsvAttr.Title}', buttonLabel1: '{twsvAttr.FirstButtonLabel}',buttonLabel2: '{twsvAttr.SecondButtonLabel}', link: '{link}', placeHolder: '{twsvAttr.PlaceHolder}' ,method: '{method}'\" ></twsv>";
                    stringBuilder.AppendLine(str);
                }
            }
            return stringBuilder.ToString();
        }
    }
}