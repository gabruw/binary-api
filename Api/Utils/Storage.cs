using Domain.Entity;

namespace Api.Utils
{
    public class Storage
    {
        public Storage()
        {

        }

        public DiffLeft Left { get; set; }
        public DiffRight Right { get; set; }

        private static Storage _instance;

        public static Storage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Storage();
            }

            return _instance;
        }
    }
}
