using System;
using Microsoft.Extensions.Configuration;

namespace comsole_sample
{
  class Program
  {
    static void Main(string[] args)
    {
      var config = new ConfigurationBuilder()
        .AddActiveProfileJsonConfiguration(true)
        .Build();
      Console.WriteLine(config["env"]);
    }
  }
}
