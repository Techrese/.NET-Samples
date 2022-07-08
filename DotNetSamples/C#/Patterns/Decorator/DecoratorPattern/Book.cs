namespace DecoratorPattern
{
    public class Book : LibraryItem
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;


        public Book(int numCopies)
        {
            this.numCopies = numCopies;
        }    

        public override void Display()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Author);
            Console.WriteLine(numCopies);
        }
    }
}


