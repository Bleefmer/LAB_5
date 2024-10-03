using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication5_2.Middleware
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath;

        public ExceptionLoggingMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _logFilePath = Path.Combine(env.ContentRootPath, "Logs", "error.txt");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        private void LogException(Exception ex)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {ex.Message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}