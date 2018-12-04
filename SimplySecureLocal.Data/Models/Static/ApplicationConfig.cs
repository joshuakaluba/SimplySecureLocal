using System;

namespace SimplySecureLocal.Data.Models.Static
{
    public static class ApplicationConfig
    {
        public static string Port
            = Environment.GetEnvironmentVariable
                ("SIMPLY_SECURE_LOCAL_APPLICATION_PORT", target: EnvironmentVariableTarget.Process);

        public static string BackendHost 
            = Environment.GetEnvironmentVariable
                ("SIMPLY_SECURE_LOCAL_BACKEND_HOST", target: EnvironmentVariableTarget.Process);

        internal static Uri BackendUri = new Uri(BackendHost);
    }
}