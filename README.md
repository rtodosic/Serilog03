## Context
1. [.Net Core Serilog – Basic](https://github.com/rtodosic/Serilog01/)
2. [.Net Core Serilog – Configuration](https://github.com/rtodosic/Serilog02/)
3. .Net Core Serilog - Structured JSON output
4. [.Net Core Serilog - Enrichers](https://github.com/rtodosic/Serilog04/)
5. [.Net Core Serilog - Custom JSON output](https://github.com/rtodosic/Serilog05/)
6. [.Net Core Serilog - Adding Sinks](https://github.com/rtodosic/Serilog06/)

This is part 3 of 6.

## 3. .Net Core Serilog - Structured JSON output

Serilog has a few ways to generate JSON output, the simplest is the “CompactJsonFormatter”. Building on the prior sample, we will add Structured JSON output.

1. Add the “Serilog.Formatting.Compact” NuGet package to your project. 
    ![Image alt text](Images/NuGet-Serilog-Compact.png?raw=true)
2. In Program.cs, add “using Serilog.Formatting.Compact;” to the top of the file and change the CreateHostBuilder() method to the following:
  ```C#
  public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          })
      .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
          .ReadFrom.Configuration(hostingContext.Configuration)
          .WriteTo.Console(new CompactJsonFormatter()) // <-- Change this line 
      );
  ```
  
3. Run the application again and notice the output. 
    ![Image alt text](Images/Console-Serilog-Compact.png?raw=true)
