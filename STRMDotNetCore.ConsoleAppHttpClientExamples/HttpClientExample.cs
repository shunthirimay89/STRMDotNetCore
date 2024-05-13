using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace STRMDotNetCore.ConsoleAppHttpClientExamples
{
    public class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7274/") };
        private readonly string _blogEndPoint= "api/blog";
        

        public async Task RunAsync() 
        {
            await ReadAsync();
            // await EditAsync(5002);
            // await EditAsync(5003);
            //await DeleteAsync(5002);
            //await CreateAsync("author","title","content");
            // await UpdateAsync( 1,"author new", "title new", "content new");
        }

        private async Task ReadAsync() 
        {
            var response=await _client.GetAsync(_blogEndPoint);
            if (response.IsSuccessStatusCode) 
            {
               string jsonStr= await response.Content.ReadAsStringAsync();
               // Console.WriteLine(jsonStr);
                List<BlogModel> list = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (var item in list) 
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Author =>{item.BlogAuthor}");
                    Console.WriteLine($"Title =>{item.BlogTitle}");
                    Console.WriteLine($"Content =>{item.BlogContent}");
                }
            }
        }

        private async Task EditAsync(int id) 
        {
            var response = await _client.GetAsync($"{_blogEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                // Console.WriteLine(jsonStr);
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Author =>{item.BlogAuthor}");
                Console.WriteLine($"Title =>{item.BlogTitle}");
                Console.WriteLine($"Content =>{item.BlogContent}");

            }
            else 
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string errormessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errormessage);
            }
        }

        private async Task CreateAsync(string author, string title, string content) 
        {
            BlogModel blogmodel = new BlogModel()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };

            string blogJson = JsonConvert.SerializeObject(blogmodel);
            HttpContent httpContent = new StringContent(blogJson,Encoding.UTF8, Application.Json);
            var response =await _client.PostAsync(_blogEndPoint,httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
           
        }

        private async Task UpdateAsync(int id,string author, string title, string content)
        {
            BlogModel blogmodel = new BlogModel()
            {
                
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };

            string blogJson = JsonConvert.SerializeObject(blogmodel);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_blogEndPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }

        }

        private async Task PatchAsync(int id, string? author=null, string? title=null, string? content=null)
        {
            BlogModel blogmodel = new BlogModel();
           
            if(author != null)
            {
                blogmodel.BlogAuthor = author;
            }
            if(title != null)
            {
                blogmodel.BlogTitle = title;
            }
            if (content != null)
            {
                blogmodel.BlogContent = content;
            }

            string blogJson = JsonConvert.SerializeObject(blogmodel);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);

            var response = await _client.PatchAsync($"{_blogEndPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }


    }
}
