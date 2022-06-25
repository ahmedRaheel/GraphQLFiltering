using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPooledDbContextFactory<WebAppContext>(options => 
    options
    .UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// builder.Services.AddPooledDbContextFactory<WebAppContext>(options => 
//     options
//    .UseSqlServer(builder.Configuration.GetConnectionString("SQLDefaultConnection"))
// );


builder
       .Services
       .AddTransient<ChatGroupService>()
       .AddGraphQLServer ()
       .AddQueryType<Query>()      
       .AddMutationType<Mutation> ()   
       .AddType<CommandType> ()
        .AddProjections()
       .AddFiltering ()
       .AddSorting ()
       .RegisterService<ChatGroupService>()
       .RegisterDbContext<WebAppContext>(kind: DbContextKind.Pooled);
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


app.MapGraphQL ("/graphql");
app.Run();
