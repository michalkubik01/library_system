namespace Program { 
    class RegularBook : Book {
        public int Pages { get; set; }

        public RegularBook(string title, string author, string isbn, int pages)
            : base(title, author, isbn) {
            Pages = pages;
        }

        public override void Display() {
            Console.WriteLine($"Regular Book: {Title}");
            Console.WriteLine($"- Author: {Author}");
            Console.WriteLine($"- Pages: {Pages}");
            Console.WriteLine($"- ISBN: {ISBN}");
            Console.WriteLine($"- Borrowed: {Borrowed}");
        }
    }
}