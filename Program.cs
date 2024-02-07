namespace Program {
    class Program {
        static void Main(string[] args) {

            Library library = new Library();

            Console.WriteLine("Prepopulating library with books and members");
            Console.WriteLine();

            library.AddBook(new RegularBook("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "1", 310));
            library.AddBook(new ReferenceBook("History of Modern Poland", "Various Authors", "2", "History"));
            library.AddBook(new DigitalBook("The Hobbit", "J.R.R. Tolkien", "3", "PDF"));

            Console.WriteLine();

            library.RegisterMember(new Member("Michal Kubik"));

            Console.WriteLine();

            Console.WriteLine("Press any key to begin");
            Console.ReadKey();

            bool running = true;

            while (running) {

                Console.Clear();

                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Register member");
                Console.WriteLine("3. Lend book");
                Console.WriteLine("4. List all books");
                Console.WriteLine("5. List all members");
                Console.WriteLine("6. Check borrowed books of a member");
                Console.WriteLine("7. Return a borrowed book");
                Console.WriteLine("8. Exit");

                Console.Write("Select an option: ");

                string? option = Console.ReadLine();
                
                Console.WriteLine();

                switch (option) {
                    case "1":
                        AddBookToLibrary(library);
                        break;
                    case "2":
                        RegisterMember(library);
                        break;
                    case "3":
                        LendBook(library);
                        break;
                    case "4":
                        ListAllBooks(library);
                        break;
                    case "5":
                        ListAllMembers(library);
                        break;
                    case "6":
                        CheckBorrowedBooks(library);
                        break;   
                    case "7":
                        ReturnBorrowedBook(library);
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

            }
        }

        static void AddBookToLibrary(Library library) {
            
            Console.Write("Enter book title: ");
            string title = Console.ReadLine() ?? "none";
            Console.Write("Enter book author: ");
            string author = Console.ReadLine() ?? "none";
            Console.Write("Enter book ISBN: ");
            string isbn = Console.ReadLine() ?? "none";
            Console.Write("Enter book type (regular, reference, digital): ");
            string type = Console.ReadLine() ?? "none";

            switch (type?.ToLower()) {
                case "regular":
                    Console.Write("Enter number of pages: ");
                    int pages = int.Parse(Console.ReadLine() ?? "0");
                    library.AddBook(new RegularBook(title, author, isbn, pages));
                    break;
                case "reference":
                    Console.Write("Enter field of study: ");
                    string field = Console.ReadLine() ?? "none";
                    library.AddBook(new ReferenceBook(title, author, isbn, field));
                    break;
                case "digital":
                    Console.Write("Enter file format: ");
                    string format = Console.ReadLine() ?? "none";
                    library.AddBook(new DigitalBook(title, author, isbn, format));
                    break;
                default:
                    Console.WriteLine("Invalid book type.");
                    break;
            }
        }

        static void RegisterMember(Library library) {
            Console.Write("Enter member name: ");
            string? name = Console.ReadLine() ?? "";
            library.RegisterMember(new Member(name));
        }

        static void LendBook(Library library) {
            Console.Write("Enter book ISBN: ");
            string? isbn = Console.ReadLine() ?? "";
            Console.Write("Enter member name: ");
            string? memberName = Console.ReadLine() ?? "";
            library.LendBook(isbn, memberName);
        }

        static void ListAllBooks(Library library) {
            List<Book> books = library.GetAllBooks();
            if (books.Count == 0) {
                Console.WriteLine("No books available.");
            } else {
                foreach (Book book in books) {
                    book.Display();
                }
            }
        }

        static void ListAllMembers(Library library) {
            List<Member> members = library.GetAllMembers();
            if (members.Count == 0) {
                Console.WriteLine("No members registered.");
            } else {
                foreach (Member member in members) {
                    Console.WriteLine($"Member Name: {member.Name}");
                }
            }
        }

        static void CheckBorrowedBooks(Library library) {
            Console.Write("Enter member name to check borrowed books: ");
            string? memberName = Console.ReadLine();
            Member? member = library.GetAllMembers().FirstOrDefault(m => m.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));

            if (member == null) {
                Console.WriteLine("Member not found.");
                return;
            }

            List<Book> borrowedBooks = member.GetBorrowedBooks();
            if (borrowedBooks.Count == 0) {
                Console.WriteLine($"{memberName} has not borrowed any books.");
            } else {
                Console.WriteLine($"{memberName} has borrowed the following books:");
                foreach (Book book in borrowedBooks) {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }
            }
        }

        static void ReturnBorrowedBook(Library library) {
            Console.Write("Enter member name: ");
            string? memberName = Console.ReadLine();
            Member? member = library.GetAllMembers().FirstOrDefault(m => m.Name.Equals(memberName, StringComparison.OrdinalIgnoreCase));

            if (member == null) {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.Write("Enter ISBN of the book to return: ");
            string? isbn = Console.ReadLine() ?? "";

            member.ReturnBook(isbn);
        }
    }
}