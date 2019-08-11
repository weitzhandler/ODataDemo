using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WashingtonSchools.Api.Models;
using Xunit;

namespace WashingtonSchools.Tests
{
  public class UnitTest1 : IDisposable
  {
    TestServer Server { get; } = new TestServer(Api.Program.CreateWebHostBuilder());
    HttpClient Client => Server.CreateClient();

    [Fact]
    public async Task TestSchools()
    {
      var settings = new ODataClientSettings(Client);
      var client = new ODataClient(settings);

      var result = await Client.GetAsync("odata/schools");
      var content = await result.Content.ReadAsStringAsync();
      var schools = JsonConvert.DeserializeObject<List<School>>(content);

      var sample = School.CreateSample();
      Assert.NotEmpty(schools);
      Assert.Contains(schools, s => s.SchoolId == sample.SchoolId);
    }               

    [Fact]
    public async Task TestMetadata()
    {

    }

    public void Dispose()
    {
      Client.Dispose();
      Server.Dispose();
    }
  }
}
