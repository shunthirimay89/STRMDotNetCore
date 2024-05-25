using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRMDotNetCore.ConsoleAppRefitExamples;

    public interface IBlogApi
    {
    [Get("/api/blog")]
    Task <List<BlogModel>> GetBlogs();

    [Get("/api/blog/{id}")]
    Task<BlogModel> GetBlog(int id);

    [Post("/api/blog")]
    Task<String> CreateBlog(BlogModel blog);

    [Put("/api/blog/{id}")]
    Task<String> UpdateBlog(int id,BlogModel blog);


    [Delete("/api/blog/{id}")]
    Task<String> DeleteBlog(int id);
}

public class BlogModel

{
    
    public int BlogId { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogContent { get; set; }



}

