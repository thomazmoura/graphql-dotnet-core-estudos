using Exemplo02.Data;
using Exemplo02.GraphQL;
using Exemplo02.Mutations;
using Exemplo02.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register Service
builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
//InMemory Database
builder.Services.AddDbContext<Contexto>(o => o.UseInMemoryDatabase("GraphQL"));
//GraphQL Config
builder.Services.AddGraphQLServer()
    .AddQueryType<ProdutoQueryTypes>()
    .AddMutationType<ProdutoMutations>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Contexto>();
    Seed.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//GraphQL
app.MapGraphQL();

app.UseAuthorization();

app.MapControllers();

app.Run();
