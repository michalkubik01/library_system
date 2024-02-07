namespace Program {
        class ReferenceBook : Book {
        public string Field { get; set; }

        public ReferenceBook(string title, string author, string isbn, string field)
            : base(title, author, isbn) {
            Field = field;
        }

        public override void Display() {
            Console.WriteLine($"Reference Book: {Title}");
            Console.WriteLine($"- Author: {Author}");
            Console.WriteLine($"- Field: {Field}");
            Console.WriteLine($"- ISBN: {ISBN}");
            Console.WriteLine($"- Borrowed: {Borrowed}");
        }
    }
}