
namespace DecoratorPattern
{
    public class Decorator : LibraryItem
    {

        protected LibraryItem libraryItem = default!;

        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public override void Display()
        {
            libraryItem.Display();
        }
    }
}
