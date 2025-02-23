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

// belirtilen id ye göre veriyi döndürür
app.MapGet("/books/{id}", (int id, BookContext db) =>
{
    var book = db.Books.FirstOrDefault(b => b.id == id);

    return book;
});

// kitap eklemek
app.MapPost("/books", async(Book book, BookContext db) =>
{
    db.Books.Add(book);

    await db.SaveChangesAsync(); // veritabanýna kaydet

    return Results.Redirect("/books");
});

// kitap verisini güncellemek
app.MapPut("/books/{id}", async(int id, Book UpdatedBook, BookContext db) =>
{
    var book = db.Books.FirstOrDefault(b => b.id == id);

    book.Title = UpdatedBook.Title;
    book.Author = UpdatedBook.Author;

    await db.SaveChangesAsync();

    return Results.Redirect("/books");
});

// kitap verisini silmek
app.MapDelete("/books/{id}", async(int id, BookContext db) =>
{
    var book = db.Books.FirstOrDefault(b => b.id == id);
    db.Books.Remove(book);

    await db.SaveChangesAsync();

    return Results.Redirect("/books");
});

app.Run();
