    public static class DotEnv
    {
        public static IDictionary<string, string> Read()
        {
            var envVars = new Dictionary<string, string>();

            // Read the .env file into a string array
            var lines = File.ReadAllLines(".env");

            // Parse each line and add to the dictionary
            foreach (var line in lines)
            {
                var parts = line.Split('=');
                envVars[parts[0]] = parts[1];
            }

            return envVars;
        }
    }