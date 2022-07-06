
namespace Singleton
{
    public sealed class Singleton
    {
        private static readonly Singleton myInstance = new Singleton();

        static Singleton() { }

        private Singleton() { }

        public static Singleton MyInstance 
        {
            get => myInstance;
        }

        public int Amount { get; set; }
    }
}
