var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "go /books");

List<Book> books = new()
{
    new Book {id = 1, Title="Yüzüklerin Efendisi", Author="J.R.R" },
    new Book {id = 2, Title="Yüksek satodaki adam", Author="Philip kindred dick" }
};

// GET request 
app.MapGet("/books", () => books);

app.Run();

class Book
{
    public int id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
