using Refit;
using STRMDotNetCore.ConsoleAppRefitExamples;
try
{
    RefitExample refitExample = new RefitExample();
    await refitExample.RunAsync();
}
catch (Exception ex) 
{
    Console.WriteLine(ex.ToString());   
}

