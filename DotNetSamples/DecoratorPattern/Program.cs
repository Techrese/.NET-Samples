using DecoratorPattern;

Book book = new Book(20);
book.Author = "jhon doe";
book.Title = "jhon doe for dummies";
book.Display();

Borrowable borrowBook = new Borrowable(book);

borrowBook.BorrowItem("me");

borrowBook.Display();
