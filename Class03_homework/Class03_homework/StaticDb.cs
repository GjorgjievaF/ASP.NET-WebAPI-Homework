using Class03_homework.Models;

namespace Class03_homework
{
    public class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book(){Title="War and Peace",Author = "Leo Tolstoy"},
            new Book(){Title="A Game of Thrones",Author = "George R.R. Martin"},
            new Book(){Title="To Kill a Mockingbird",Author = "Harper Lee"},
            new Book(){Title="Hamlet",Author = "William Shakespeare"},
            new Book(){Title="The House of the Spirits",Author = "Isabel Allende "},
            new Book(){Title=" The Lord of the Rings",Author = "J.R.R. Tolkien"},
            new Book(){Title="Crime and Punishment",Author = "Fyodor Dostoevsky "},
            new Book(){Title="Arabian Nights",Author = "Gabriel Garca Marquez"},
            new Book(){Title="The Diary of a Young Girl ",Author = " Anne Frank"},
        };
    }
}
