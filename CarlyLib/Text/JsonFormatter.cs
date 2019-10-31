using System;
using System.IO;
using System.Text;
namespace CarlyLib.Text
{
    public class JsonFormatter : IFormattable
    {
        int indentLength;

        public JsonFormatter()
        {
            indentLength = 2;
        }

        public JsonFormatter(int indentLength)
        {
            this.indentLength = indentLength;
        }


        public string Format(string json)
        {
            if(string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");


            StringBuilder builder = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;

            foreach(char ch in json)
            {
                switch(ch)
                {
                    case '"':
                        if(!ignore) quote = !quote;
                        break;
                    case '\\':
                        if(quote) ignore = !ignore;
                        break;
                }

                if(quote)
                    builder.Append(ch);
                else
                {
                    switch(ch)
                    {
                        case '{':
                        case '[':
                            builder.Append(ch);
                            builder.Append(Environment.NewLine);
                            builder.Append(new string(' ', ++offset * indentLength));
                            break;

                        case '}':
                        case ']':
                            builder.Append(Environment.NewLine);
                            builder.Append(new string(' ', --offset * indentLength));
                            builder.Append(ch);
                            break;

                        case ',':
                            builder.Append(ch);
                            builder.Append(Environment.NewLine);
                            builder.Append(new string(' ', offset * indentLength));
                            break;

                        case ':':
                            builder.Append(ch);
                            builder.Append(' ');
                            break;

                        default:
                            if(ch != ' ') builder.Append(ch);
                            break;
                    }
                }
            }


            return builder.ToString().Trim();
        }
    }
}
