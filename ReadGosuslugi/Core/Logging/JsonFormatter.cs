using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Json;
using System;
using System.IO;
using System.Reflection;

namespace ReadGosuslugi.Core.Logging
{
    public class JsonFormatter : ITextFormatter
    {
        readonly JsonValueFormatter _valueFormatter;

        public JsonFormatter(JsonValueFormatter valueFormatter = null)
        {
            _valueFormatter = valueFormatter ?? new JsonValueFormatter(typeTagName: "$type");
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            FormatEvent(logEvent, output, _valueFormatter);
            output.WriteLine();
        }

        public static void FormatEvent(LogEvent logEvent, TextWriter output, JsonValueFormatter valueFormatter)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (valueFormatter == null) throw new ArgumentNullException(nameof(valueFormatter));

            output.Write("{\"Date\":\"");
            output.Write(logEvent.Timestamp.UtcDateTime.ToString("O"));

            output.Write("\", \"ProjectName\":\"");
            output.Write(Assembly.GetCallingAssembly().GetName().Name);

            output.Write("\", \"CategoryName\":\"");
            output.Write(string.Empty);

            output.Write("\", \"UserName\":\"");
            output.Write(string.Empty);

            output.Write("\", \"LogLevel\":\"");
            output.Write(logEvent.Level);

            output.Write("\",\"Message\":");
            var message = logEvent.MessageTemplate.Render(logEvent.Properties);
            JsonValueFormatter.WriteQuotedJsonString(message, output);

            if (logEvent.Exception != null)
            {
                output.Write(",\"StackTrace\":");
                JsonValueFormatter.WriteQuotedJsonString(logEvent.Exception.ToString(), output);
            }

            foreach (var property in logEvent.Properties)
            {
                var name = property.Key;
                if (name.Length > 0 && name[0] == '@')
                    name = '@' + name;
                
                output.Write(',');
                JsonValueFormatter.WriteQuotedJsonString(name, output);
                output.Write(':');
                valueFormatter.Format(property.Value, output);
            }

            output.Write('}');
        }
    }
}
