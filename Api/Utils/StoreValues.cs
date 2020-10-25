using Domain.Entity;

namespace Api.Utils
{
    public class StoreValues
    {
        public StoreValues()
        {

        }

        public DiffLeft Left { get; set; }
        public DiffRight Right { get; set; }

        private static StoreValues _instance;

        public static StoreValues GetInstance()
        {
            if (_instance == null)
            {
                _instance = new StoreValues();
            }

            return _instance;
        }
    }
}
