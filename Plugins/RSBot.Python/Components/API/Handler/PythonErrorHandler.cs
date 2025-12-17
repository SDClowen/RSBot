using Python.Runtime;
using System;
using System.Text;

namespace RSBot.Python.Components.API.Handler
{
    public static class PythonErrorHandler
    {
        public static string FormatException(PythonException ex)
        {
            var sb = new StringBuilder();

            sb.AppendLine("PYTHON ERROR");
            sb.AppendLine("──────────────────────────────");

            try
            {
                sb.AppendLine($"Type: {ex.Type}");
                sb.AppendLine($"Message: {ex.Message}");
                sb.AppendLine();

                if (ex.StackTrace != null)
                {
                    sb.AppendLine("Stacktrace:");
                    sb.AppendLine(ex.StackTrace);
                }
            }
            catch { }

            sb.AppendLine("──────────────────────────────");

            return sb.ToString();
        }
    }
}
