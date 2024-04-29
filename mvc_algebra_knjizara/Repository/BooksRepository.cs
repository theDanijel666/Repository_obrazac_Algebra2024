using mvc_algebra_knjizara.Models;

namespace mvc_algebra_knjizara.Repository
{
    public class BooksRepository
    {
        private static List<Book> books;

        public BooksRepository()
        {
            if(books == null)
            {
                books = new List<Book>();
                //popuniti listu podataka pomoću nekog izvora...
                SimulateDatabase();
            }
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = books.Where(x=>x.BookId==id).FirstOrDefault();
            return book;
        }

        public void CreateNewBook(Book new_book)
        {
            if (new_book == null) return;
            if (new_book.BookId <= 0)
            {
                new_book.BookId = next_bookID();
            }
            var exists= books.Where(x=>x.BookId == new_book.BookId).FirstOrDefault();
            if(exists != null) 
            {
                throw new Exception("There allready exists a book with that ID!"); 
            }
            books.Add(new_book);
        }

        private int next_bookID()
        {
            int bid=books.Max(x => x.BookId);
            return bid+1;
        }

        public void DeleteBook(int id)
        {
            books.Remove(GetBookById(id)); 
        }

        public void UpdateBook(Book updated_book)
        {
            var book=GetBookById(updated_book.BookId);
            if(book == null)
            {
                //neispravan bookID, knjiga ne postoji u bazi/listi
                throw new Exception("Knjiga ne postoji u bazi, pa ne može biti ažurirana!");
            }
            book.Title = updated_book.Title;
            book.Description = updated_book.Description;
            book.Genre = updated_book.Genre;
            book.Stock = updated_book.Stock;
            book.ReleaseDate = updated_book.ReleaseDate;
            book.Author = updated_book.Author;
        }

        private void SimulateDatabase()
        {
            Book b1= new Book()
            {
                BookId = 1,
                Title="Gospodar prstenova",
                Description="Treba prsten odnijet na mordor...",
                Genre="fantasy",
                Stock=11,
                ReleaseDate=new DateTime(1954,3,2),
                Author="Tolkien"
            };
            books.Add(b1);

            Book b2 = new Book()
            {
                BookId = 2,
                Title = "Zbirka pjesama",
                Description = "Zbirka pjesama Tina Ujevića",
                Genre = "Poezija",
                Stock = 62,
                ReleaseDate = new DateTime(1953, 9, 9),
                Author="Tin Ujević"
            };
            books.Add(b2);

            Book b3 = new Book()
            {
                BookId = 3,
                Title = "Holly",
                Description = "Nestanci ljudi u jednom malom mjestu",
                Genre = "Horor",
                Stock = 17,
                ReleaseDate = new DateTime(2023,1,1),
                Author = "Stephen King"
            };
            books.Add(b3);

            Book b4 = new Book()
            {
                BookId = 4,
                Title = "Harry Potter",
                Description = "Mladi čarobnjak ide u školu",
                Genre = "Fantasy",
                Stock = 2,
                ReleaseDate = new DateTime(1987,1,1),
                Author = "J.K. Rowling"
            };
            books.Add(b4);

            Book b5 = new Book()
            {
                BookId = 5,
                Title = "Sous-vide at home",
                Description = "Recepti za kuhanbje sous-vide stilom",
                Genre = "Kuharica",
                Stock = 32,
                ReleaseDate = new DateTime(2016,1,1),
                Author = "L.Q.Fetterman"
            };
            books.Add(b5);
        }
    }
}
