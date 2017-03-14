namespace FSL.XF3.Services
{
    public sealed class FslApiClient
    {
        private static volatile ICustomersApiClient _instance;
        private static object syncRoot = new object();
        
        public static ICustomersApiClient Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        _instance = new CustomersApiClient(); // You can use Dependency Injection
                    }
                }

                return _instance;
            }
        }
    }
}
