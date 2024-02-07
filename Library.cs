namespace Program {
    class Library {

        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();
        
        public void AddBook(Book book) {
            books.Add(book);
        }
        
        public void RegisterMember(Member member) {
            members.Add(member);
        }
        
        public void LendBook(string isbn, string memberName) {

            Book? book = books.FirstOrDefault(b => b.ISBN == isbn);
            Member? member = members.FirstOrDefault(m => m.Name == memberName);

            if (book is null) Console.WriteLine($"Book with ISBN \"{isbn}\" not found.");
            if (member is null) Console.WriteLine($"Member {memberName} not found.");
            if (book!.Borrowed) Console.WriteLine($"Book is currently not available.");
            if (book is not null && member is not null && !book.Borrowed) member.BorrowBook(book);
        }

        public List<Book> GetAllBooks() {
            return books;
        }

        public List<Member> GetAllMembers() {
            return members;
        }
    }
}