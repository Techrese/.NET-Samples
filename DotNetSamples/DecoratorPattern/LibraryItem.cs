namespace DecoratorPattern
{
    public abstract class LibraryItem
    {
        public int numCopies { get; set; }

        public abstract void Display();
    }
}
