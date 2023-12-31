﻿using BixbyShop_LK.Config.DI;

namespace BixbyShop_LK.Config
{
    [Component]
    public class EnvironmentService
    {
        public void setEnvironmentVariable(String key, String value)
        {
            Environment.SetEnvironmentVariable(key, value, EnvironmentVariableTarget.Process);
        }

        public String getEnvironmentVariable(String key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}
