using BasicAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// veritabaný baðlantýsý
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlite("Data Source=Library.db"));

var app = builder.Build();

app.MapGet("/", () => "go /books");

// bütün kitap verilerini döndürür
app.MapGet("/books", async (BookContext db) =>
{
    return db.Books;
});

/*

// belirtilen id ye göre veriyi döndürür
app.MapGet("/books/{id}", (int id) =>
{
    var book = books.FirstOrDefault(b => b.id == id); // eslesen id ye göre veriyi depola
    return book;
});

*/

// kitap eklemek
app.MapPost("/books", async(Book book, BookContext db) =>
{

    db.Books.Add(book);
    await db.SaveChangesAsync(); // veritabanýna kaydet
    return Results.Redirect("/books");
});

/*

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

*/

app.Run();
