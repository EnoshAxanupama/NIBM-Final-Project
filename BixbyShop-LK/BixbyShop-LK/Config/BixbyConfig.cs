namespace BixbyShop_LK.Config
{
    public class MapValue
    {
        public string Value { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsExpired => DateTime.Now > ExpirationTime;
    }
    public class MapService
    {
        private Thread backgroundThread;
        private bool running;
        private Dictionary<String, MapValue> map;

        public bool delete(String key)
        {
            return map.Remove(key);
        }
        public Dictionary<String, MapValue> Map
        {
            get { return map; }
        }
        public MapService()
        {
            running = false;
            map = new Dictionary<String, MapValue>();
        }

        public void Start()
        {
            backgroundThread = new Thread(BackgroundLogic);
            backgroundThread.Start();
            running = true;
        }

        public void Stop()
        {
            running = false;
            backgroundThread.Join();
        }

        public void AddOrUpdateMapValue(String number, string value)
        {
            DateTime expirationTime = DateTime.Now.AddMinutes(15);
            bool isExpired = false;

            if (map.ContainsKey(number))
            {
                var existingValue = map[number];
                existingValue.Value = value;
                existingValue.ExpirationTime = expirationTime;
                isExpired = existingValue.IsExpired;
            }
            else
            {
                var newValue = new MapValue
                {
                    Value = value,
                    ExpirationTime = expirationTime
                };
                map[number] = newValue;
            }

            Console.WriteLine($"Map value with number {number} {(isExpired ? "expired" : "added/updated")}.");
        }

        private void BackgroundLogic()
        {
            while (running)
            {
                foreach (var keyValue in map)
                {
                    var mapValue = keyValue.Value;
                    if (mapValue.IsExpired)
                    {
                        mapValue.Value = null;
                        Console.WriteLine($"Map value with number {keyValue.Key} expired.");
                    }
                }
                Thread.Sleep(TimeSpan.FromMinutes(15));
            }
        }
    }

    public static class BixbyConfig
    {
        public delegate int CallbackDelegate(String? email, String? code);

        //private static readonly EnvironmentService _environmentService = new EnvironmentService();
        public static MapService service = new MapService();

        public static void startUp()
        {
            service.Start();
        }

        public static int EmailAndAccountVerificationValidation_TakeTheAction(String? email, String code, CallbackDelegate callback)
        {
            return callback(email, code);
        }

        public static void stopUp()
        {
            service.Stop();
        }
    }
}
