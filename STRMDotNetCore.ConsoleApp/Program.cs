// See https://aka.ms/new-console-template for more information
using STRMDotNetCore.ConsoleApp.AdoDotNetExamples;
using STRMDotNetCore.ConsoleApp.EFCoreExamples;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello World");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();
//adoDotNetExample.Create("Author","Title", "Content");
//adoDotNetExample.Update(1, "Author", "Title", "Content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Edit(9);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();
Console.ReadKey();
