var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "go /books");

List<Book> books = new()
{
    new Book {id = 1, Title="Y�z�klerin Efendisi", Author="J.R.R" },
    new Book {id = 2, Title="Y�ksek satodaki adam", Author="Philip Kindred Dick" }
};

// b�t�n kitap verilerini d�nd�r�r
app.MapGet("/books", () => books);

// belirtilen id ye g�re veriyi d�nd�r�r
app.MapGet("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(book => book.id == id); // eslesen id ye g�re veriyi depola
    return book;
});

// kitap eklemek
app.MapPost("/books", (Book book) =>
{
    book.id = books.Max(b => b.id) + 1; //say� olarak en b�y�k id ye 1 ekler
    books.Add(book);
    return Results.Redirect("/books");
});

app.Run();

class Book
{
    public int id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
