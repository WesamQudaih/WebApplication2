using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




//posts api
app.MapGet("/api/posts/{id}", () =>
    {
        return Results.Ok(Data.posts);
    });

app.MapGet("/api/posts/{id}", (int id) =>
{
    var post = Data.posts.FirstOrDefult(post =>  post.Id == id);
    if (post is null)
        return Results.NotFound(new
        {
            Message = "post not found"
        });

    return Results.Ok(posts);
});

app.Run();
