namespace BixbyShop_LK.Config
{
    public static class EnvironmentService
    {
        public static void setEnvironmentVariable(String key, String value)
        {
            Environment.SetEnvironmentVariable(key, value, EnvironmentVariableTarget.Process);
        }

        public static String getEnvironmentVariable(String key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
