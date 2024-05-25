using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STRMDotNetCore.ConsoleAppRefitExamples;

    public class RefitExample
    {
    private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7080");
    public async Task RunAsync() 
    {
        //await ReadAsync();
        //await EditAsync(1);
        //await EditAsync(100);
        //await CreateAsync("title", "author 2", "content 3");
       // await UpdateAsync(14, "title 1", "author 2", "content 3");
        await DeleteAsync(8);
    }

    private async Task ReadAsync() 
    {
        
        var list = await _service.GetBlogs();
        foreach (var item in list)
        {
            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("____");
        }
    }

    private async Task EditAsync(int id)
    {
        try
        {
            var item = await _service.GetBlog(id);

            Console.WriteLine($"Id => {item.BlogId}");
            Console.WriteLine($"Title => {item.BlogTitle}");
            Console.WriteLine($"Author => {item.BlogAuthor}");
            Console.WriteLine($"Content => {item.BlogContent}");
            Console.WriteLine("____");
        }
        catch (ApiException ex) 
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }

        catch (Exception ex)
        {

        }
    }
    private async Task CreateAsync(string title, string author, string content) 
    {
        BlogModel blogModel = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
         var message= await _service.CreateBlog(blogModel);
        Console.WriteLine(message);
    }

    private async Task UpdateAsync(int id,string title, string author, string content)
    {
        BlogModel blogModel = new BlogModel()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        try 
        {
            var message = await _service.UpdateBlog(id, blogModel);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }

        catch (Exception ex)
        {

        }

    }

    private async Task DeleteAsync(int id) 
    {
        try
        {
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }

        catch (Exception ex)
        {

        }
    }

}

