var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "go /books");

List<Book> books = new()
{
    new Book {id = 1, Title="Yüzüklerin Efendisi", Author="J.R.R Tolkien" },
    new Book {id = 2, Title="Yüksek satodaki adam", Author="Philip Kindred Dick" }
};

// bütün kitap verilerini döndürür
app.MapGet("/books", () => books);

// belirtilen id ye göre veriyi döndürür
app.MapGet("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(b => b.id == id); // eslesen id ye göre veriyi depola
    return book;
});

// kitap eklemek
app.MapPost("/books", (Book book) =>
{
    book.id = books.Max(b => b.id) + 1; //sayý olarak en büyük id ye 1 ekler
    books.Add(book);
    return Results.Redirect("/books");
});

// kitap verisini güncellemek
app.MapPut("/books/{id}", (int id, Book UpdatedBook) =>
{
    var OldBook = books.FirstOrDefault(b => b.id == id);

    OldBook.Title = UpdatedBook.Title;
    OldBook.Author = UpdatedBook.Author;
    return Results.Redirect("/books");
});

// kitap verisini silmek
app.MapDelete("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(b => b.id == id);
    books.Remove(book);
    return Results.Redirect("/books");
});

app.Run();

class Book
{
    public int id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
