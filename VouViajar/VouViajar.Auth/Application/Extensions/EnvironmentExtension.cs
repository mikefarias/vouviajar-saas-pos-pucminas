namespace VouViajar.Auth.Application.Extensions
{
    public static class EnvironmentExtension
    {
        /// <summary>
        /// obtem variável de ambiente
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static string GetEnvironmentVariable(string environment)
            => Environment.GetEnvironmentVariable(environment)
                ?? throw new InvalidOperationException($"Não foi possível encontrar a variável de ambiente {environment}");
    }
}