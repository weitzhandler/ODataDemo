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

    HttpClient _Client;
    public HttpClient Client
    {
      get
      {
        if (_Client == null)
        {
          _Client = Server.CreateClient();
          var builder = new UriBuilder(_Client.BaseAddress);
          builder.Path += "odata/";
          _Client.BaseAddress = builder.Uri;
        }

        return _Client;
      }
    }



    [Fact]
    public async Task TestSchools()
    {
      var result = await Client.GetAsync("schools");
      var content = await result.Content.ReadAsStringAsync();
      var schools = JsonConvert.DeserializeObject<List<School>>(content);

      var sample = School.CreateSample();
      Assert.NotEmpty(schools);
      Assert.Contains(schools, s => s.SchoolId == sample.SchoolId);
    }

    [Fact]
    public async Task TestMetadata()
    {
      var settings = new ODataClientSettings(Client);
      var client = new ODataClient(settings);

      var metadata = await client.GetMetadataDocumentAsync();

      var schools =
        await client
          .For<School>()
          .FindEntriesAsync();

      var sample = School.CreateSample();
      Assert.NotEmpty(schools);
      Assert.Contains(schools, s => s.SchoolId == sample.SchoolId);
    }

    public void Dispose()
    {
      Client.Dispose();
      Server.Dispose();
    }
  }
}
