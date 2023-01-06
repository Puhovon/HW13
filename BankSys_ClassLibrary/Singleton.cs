namespace HW13.Utils
{
    public abstract class Singleton<T>
        where T : new()
    {
        private static T _instance;

        public static T I
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new T();
                    (_instance as Singleton<T>)?.Init();
                }
                return _instance;
            }
        }
        protected Singleton() { }
        protected abstract void Init();
    }
}
