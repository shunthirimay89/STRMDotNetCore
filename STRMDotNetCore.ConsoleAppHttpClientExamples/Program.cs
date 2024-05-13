// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using STRMDotNetCore.ConsoleAppHttpClientExamples;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

//ConsoleApp (client)
//Web Api (backend)

//HttpClient client = new HttpClient();

//if (response.IsSuccessStatusCode) 
//{
//   string jsonStr= await response.Content.ReadAsStringAsync();
//   // Console.WriteLine(jsonStr);
//    List<BlogModel> list = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
//    foreach (var item in list) 
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(item));
//        Console.WriteLine($"Author =>{item.BlogAuthor}");
//        Console.WriteLine($"Title =>{item.BlogTitle}");
//        Console.WriteLine($"Content =>{item.BlogContent}");
//    }
//}

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();
Console.ReadLine();