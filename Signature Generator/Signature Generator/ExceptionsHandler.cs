using System;

namespace Signature_Generator
{
    class ExceptionsHandler
    {
        private static void Handler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;
            Console.Error.WriteLine(exception.Message);
            Console.Error.WriteLine(exception.StackTrace);
        }
        public static void HandleAllExceptions()
        {
            AppDomain.CurrentDomain.UnhandledException += Handler;
        }
    }
}
