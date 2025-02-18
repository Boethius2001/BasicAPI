var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

List<Book> books = new()
{
    new Book {id = 1, Title="Lord of the rings", Author="Tolkien" }
};


app.Run();

class Book
{
    public int id;
    public string Title;
    public string Author;
}
