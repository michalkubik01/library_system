namespace Program {
    class Member {
        public string Name { get; set; }
        private List<Book> borrowedBooks = new List<Book>();
        
        public Member(string name) {
            Name = name;
        }
        
        public void BorrowBook(Book book) {
            borrowedBooks.Add(book);
            book.Borrowed = true;
            Console.WriteLine($"{Name} has borrowed {book.Title}.");
        }

        public List<Book> GetBorrowedBooks() {
            return borrowedBooks;
        }

        public void ReturnBook(string isbn) {
            Book? book = borrowedBooks.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null) {
                borrowedBooks.Remove(book);
                book.Borrowed = false;
                Console.WriteLine($"{Name} has returned {book.Title}.");
            } else {
                Console.WriteLine($"Book with ISBN {isbn} is not currently borrowed by {Name}.");
            }
        }
    }
}