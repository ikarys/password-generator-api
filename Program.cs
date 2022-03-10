var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/generate-password", (int? length, bool? specials) =>
{
    if (length == null)
    {
        length = 8;
    }
    if (specials == null)
    {
        specials = false;
    }
    string password = Iksoftware.CredentialGenerator.GeneratePassword((int)length, specials = (bool)specials);
    return password;
})
.WithName("GeneratePassword");

app.Run();

