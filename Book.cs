namespace Program {
    abstract class Book {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Borrowed { get; set; } = false;
        
        protected Book(string title, string author, string isbn) {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public abstract void Display();
    }
}