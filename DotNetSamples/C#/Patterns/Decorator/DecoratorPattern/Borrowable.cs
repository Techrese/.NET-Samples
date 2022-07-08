namespace DecoratorPattern
{
    public class Borrowable : Decorator
    {

        protected readonly List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem libraryItem) : base(libraryItem)
        {

        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.numCopies--;
        }
        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.numCopies++;
        }

        public override void Display()
        {
            base.Display();
            foreach (string borrower in borrowers)
            {
                Console.WriteLine($" borrower: {borrower}");
            }
        }

    }
}
