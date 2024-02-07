namespace Program {
        class DigitalBook : Book {
        public string FileFormat { get; set; }

        public DigitalBook(string title, string author, string isbn, string fileFormat)
            : base(title, author, isbn) {
            FileFormat = fileFormat;
        }

        public override void Display() {
            Console.WriteLine($"Digital Book: {Title}");
            Console.WriteLine($"- Author: {Author}");
            Console.WriteLine($"- FileFormat: {FileFormat}");
            Console.WriteLine($"- ISBN: {ISBN}");
            Console.WriteLine($"- Borrowed: {Borrowed}");
        }
    }
}