using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.AgencySystem.Helpers
{
    public class UrlArgumentsExtractor
    {
        private readonly string _arguments;
        public string Url { get; }

        public UrlArgumentsExtractor(string url)
        {
            if (String.IsNullOrEmpty(url))
                throw new ArgumentException("The url argument cannot contain an empty string or a null value", nameof(url));
            _arguments = url.Substring(url.IndexOf("?") + 1);
            Url = url;
        }


        public string GetValue(string paramName)
        {
            string[] subs = _arguments.Split('&');
            for (int i = 0; i < subs.Length; i++)
            {
                if (subs[i].Contains(paramName))                
                    return subs[i].Substring(subs[i].IndexOf('=') + 1);
            }
            return "";
        }

    }
}
