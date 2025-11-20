This file is a merged representation of a subset of the codebase, containing specifically included files and files not matching ignore patterns, combined into a single document by Repomix.
The content has been processed where empty lines have been removed.

<file_summary>
This section contains a summary of this file.

<purpose>
This file contains a packed representation of a subset of the repository's contents that is considered the most important context.
It is designed to be easily consumable by AI systems for analysis, code review,
or other automated processes.
</purpose>

<file_format>
The content is organized as follows:
1. This summary section
2. Repository information
3. Directory structure
4. Repository files (if enabled)
5. Multiple file entries, each consisting of:
  - File path as an attribute
  - Full contents of the file
</file_format>

<usage_guidelines>
- This file should be treated as read-only. Any changes should be made to the
  original repository files, not this packed version.
- When processing this file, use the file path to distinguish
  between different files in the repository.
- Be aware that this file may contain sensitive information. Handle it with
  the same level of security as you would the original repository.
</usage_guidelines>

<notes>
- Some files may have been excluded based on .gitignore rules and Repomix's configuration
- Binary files are not included in this packed representation. Please refer to the Repository Structure section for a complete list of file paths, including binary files
- Only files matching these patterns are included: Client/App.razor, Client/_Imports.razor, Client/Program.cs, Client/Components/**/*.razor, Client/Layout/**/*.razor, Client/Pages/**/*.razor, Client/Service/**/*.cs, Core/**/*.cs, Server/Controllers/**/*.cs, Server/Repositories/**/*.cs, Server/Program.cs, Server/appsettings*.json
- Files matching these patterns are excluded: **/bin/**, **/obj/**, **/*.csproj, **/*.sln, **/*.css, **/*.map, **/*.min.js, **/wwwroot/**, ServerApp/ServerApp.http
- Files matching patterns in .gitignore are excluded
- Files matching default ignore patterns are excluded
- Empty lines have been removed from all files
- Files are sorted by Git change count (files with more changes are at the bottom)
</notes>

</file_summary>

<directory_structure>
Client/
  Components/
    Marked/
      MarkedComponent.razor
      MarkedDetailsComponent.razor
      MarkedFilter.razor
      MarkedGrid.razor
    AnnonceCard.razor
  Layout/
    MainLayout.razor
    NavMenu.razor
  Pages/
    Home.razor
    MarkedDetailPage.razor
    MarkedPage.razor
    MineAnnoncerPage.razor
    MineKøbPage.razor
    OpretBruger.razor
    TilføjAnnonce.razor
  Service/
    BrugerServiceHttp.cs
    IBrugerService.cs
    Server.cs
  _Imports.razor
  App.razor
  Program.cs
Core/
  Anmodning.cs
  Annonce.cs
  Bruger.cs
  Lokation.cs
Server/
  Controllers/
    AnnonceController.cs
    BrugerController.cs
    WeatherForecastController.cs
  Repositories/
    AnnonceRepositoryMongoDb.cs
    BrugerRepo.cs
    IAnnonceRepository.cs
    IBrugerRepo.cs
  appsettings.Development.json
  appsettings.json
  Program.cs
</directory_structure>

<files>
This section contains the contents of the repository's files.

<file path="Client/Pages/Home.razor">
@page "/"

<PageTitle>Home</PageTitle>

<h1>Hello, world!</h1>

Welcome to your new app.
</file>

<file path="Client/Pages/MineKøbPage.razor">
@page "/indkøb"

<h3>MineKøbPage</h3>

@code {

}
</file>

<file path="Client/Pages/TilføjAnnonce.razor">
@page "/TilføjAnnonce"
@using Core
@inject HttpClient Http
@using Client.Components

<h3>TilføjAnnonce</h3>

<EditForm Model="@annonce" class="row p-3">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div class="col-md-12 mb-3">
        <label for="Name">Name</label>
        <InputText id="Name" @bind-Value="annonce.Title" class="form-control"/>
    </div>

    <div class="col-md-6 mb-3">
        <label for="Price">Price</label>
        <InputNumber id="Price" @bind-Value="annonce.Price" class="form-control"/>
    </div>

    <div class="col-md-6 mb-3">
        <label for="Price">Category</label>
        <InputSelect id="Category" @bind-Value="annonce.Category" class="form-control">
            @foreach (var c in catagories)
            {
                <option value="@c">@c</option>
            }
        </InputSelect>
    </div>
    
    <div class="col-md-6 mb-3">
        <label for="Price">Location</label>
        <InputSelect id="Location" @bind-Value="annonce.Location" class="form-control">
            @foreach (var l in locations)
            {
                <option value="@l">@l</option>
            }
        </InputSelect>
    </div>

    <div class="col-md-12 mb-3">
        <label for="Description">Description</label>
        <InputTextArea id="Description" @bind-Value="annonce.Description" class="form-control"/>
    </div>

    <div class="d-flex justify-content-between align-items-center mt-3">
        <div class="d-flex gap-2">
            <button type="submit" class="btn btn-success" @onclick="OnClickAddProduct">Submit</button>
        </div>
    </div>
</EditForm>

@code {

    private List<Annonce> annoncer = new();
    
    private Annonce annonce = new();          
    private string errorText = "";      

    private string[] catagories = { "--Vælg en kategori--", "Elektronik", "Bil", "Møbler", "Tøj", "Kunst", "Have" };
    private string[] locations = { "--Vælg et lokale--", "SH-A1.06", "SH-A1.02" };
    
    protected override async Task OnInitializedAsync()
    {
        annoncer = await Http.GetFromJsonAsync<List<Annonce>>("http://localhost:5044/api/annonce");
    }

    private async Task OnClickAddProduct()
    {
        errorText = "";
        try
        {
            var response = await Http.PostAsJsonAsync("http://localhost:5044/api/annonce", annonce);

            if (response.IsSuccessStatusCode)
            {
                // clear the form after successful create
                annonce = new Annonce();
            }
            else
            {
                errorText = $"Kunne ikke oprette bruger (status { (int)response.StatusCode }).";
            }
        }
        catch
        {
            errorText = "Fejl ved forbindelse til API'et.";
        }
    }
}
</file>

<file path="Client/_Imports.razor">
@using System.Net.Http
@using System.Net.Http.Json
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.AspNetCore.Components.WebAssembly.Http
@using Microsoft.JSInterop
@using Client
@using Client.Layout
</file>

<file path="Client/App.razor">
<Router AppAssembly="@typeof(App).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)"/>
        <FocusOnNavigate RouteData="@routeData" Selector="h1"/>
    </Found>
    <NotFound>
        <PageTitle>Not found</PageTitle>
        <LayoutView Layout="@typeof(MainLayout)">
            <p role="alert">Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
</file>

<file path="Core/Anmodning.cs">
namespace Core;
public class Anmodning
{
    public int AnmodningId { get; set; }
    public int BrugerId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
}
</file>

<file path="Core/Lokation.cs">
namespace Core;
public class Lokation
{
    public int LokationId { get; set; }
    public string Name { get; set; }
}
</file>

<file path="Server/Controllers/WeatherForecastController.cs">
using Microsoft.AspNetCore.Mvc;
namespace Server.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ILogger<WeatherForecastController> _logger;
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
</file>

<file path="Server/appsettings.Development.json">
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
</file>

<file path="Server/appsettings.json">
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
</file>

<file path="Client/Components/Marked/MarkedDetailsComponent.razor">
@using Core

<div class="product-detail container-xl">
  
  @if (Annonce != null)
  {
    <div class="gallery">
      <div class="main-image">
        <img src="@Annonce.ImageUrl" alt="@Annonce?.Title" loading="lazy"/>
      </div>
    </div>


    <aside class="details">
      <h1 class="title">@Annonce?.Title</h1>
      <span class="price">@Annonce?.Price.ToString("N0") kr.</span>
      <div class="desc">
        @if (!string.IsNullOrWhiteSpace(Annonce?.Description))
        {
          <p>@Annonce.Description</p>
        }
      </div>
      <div class="actions">
        <button class="btn primary" @onclick="OnSendMessage">Andmod om køb</button>
      </div>
      <dl class="meta-list">
        <dt>Sælger</dt><dd>@Annonce?.SælgerId</dd>
        <dt>Lokation</dt><dd>@Annonce?.Location</dd>
        <dt>Kategori</dt><dd>@Annonce?.Category</dd>
      </dl>
    </aside>
  }
</div >
      

  @code {
    [Parameter] public Annonce? Annonce { get; set; }

    
    

    private void OnSendMessage()
    {
        Console.WriteLine($"Send besked for annonce {Annonce?.AnonnceId}");
    }

   
}
</file>

<file path="Client/Components/Marked/MarkedFilter.razor">
@namespace Client.Components.Marked

<div class="categories" role="navigation" aria-label="Kategorier">
    
    <button class='category @(Selected == "Elektronik" ? "active" : "")' 
            @onclick='() => SelectCategory("Elektronik")'>
        <div class="icon-wrap">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"width="18"height="18"><path d="M4 5V16H20V5H4ZM2 4.00748C2 3.45107 2.45531 3 2.9918 3H21.0082C21.556 3 22 3.44892 22 4.00748V18H2V4.00748ZM1 19H23V21H1V19Z"></path></svg>
        </div>
        <div>Elektronik</div>
    </button>

    <button class='category @(Selected == "Bil" ? "active" : "")' @onclick='() => SelectCategory("Bil")'>
        <div class="icon-wrap">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"width="18" height="18"><path d="M19 20H5V21C5 21.5523 4.55228 22 4 22H3C2.44772 22 2 21.5523 2 21V13.5L0.757464 13.1894C0.312297 13.0781 0 12.6781 0 12.2192V11.5C0 11.2239 0.223858 11 0.5 11H2L4.4805 5.21216C4.79566 4.47679 5.51874 4 6.31879 4H17.6812C18.4813 4 19.2043 4.47679 19.5195 5.21216L22 11H23.5C23.7761 11 24 11.2239 24 11.5V12.2192C24 12.6781 23.6877 13.0781 23.2425 13.1894L22 13.5V21C22 21.5523 21.5523 22 21 22H20C19.4477 22 19 21.5523 19 21V20ZM20 18V13H4V18H20ZM5.47703 11H18.523C18.6502 11 18.7762 10.9757 18.8944 10.9285C19.4071 10.7234 19.6566 10.1414 19.4514 9.62861L18 6H6L4.54856 9.62861C4.50131 9.74673 4.47703 9.87278 4.47703 10C4.47703 10.5523 4.92475 11 5.47703 11ZM5 14C7.31672 14 8.87868 14.7548 9.68588 16.2643L9.68582 16.2643C9.81602 16.5078 9.72418 16.8107 9.4807 16.9409C9.40818 16.9797 9.3272 17 9.24496 17H6C5.44772 17 5 16.5523 5 16V14ZM19 14V16C19 16.5523 18.5523 17 18 17H14.755C14.6728 17 14.5918 16.9797 14.5193 16.9409C14.2758 16.8107 14.184 16.5078 14.3142 16.2643L14.3141 16.2643C15.1213 14.7548 16.6833 14 19 14Z"></path></svg>
        </div>
        <div>Bil</div>
    </button>
    
    <button class='category @(Selected == "Møbler" ? "active" : "")' @onclick='() => SelectCategory("Møbler")'>
        <div class="icon-wrap">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"width="18"height="18"><path d="M8 3C5.79086 3 4 4.79086 4 7V9.12602C2.27477 9.57006 1 11.1362 1 13C1 14.4817 1.8052 15.7734 3 16.4646V19V21H5V20H19V21H21V19V16.4646C22.1948 15.7734 23 14.4817 23 13C23 11.1362 21.7252 9.57006 20 9.12602V7C20 4.79086 18.2091 3 16 3H8ZM18 9.12602C16.2748 9.57006 15 11.1362 15 13H9C9 11.1362 7.72523 9.57006 6 9.12602V7C6 5.89543 6.89543 5 8 5H16C17.1046 5 18 5.89543 18 7V9.12602ZM9 15H15V16H17V13C17 11.8954 17.8954 11 19 11C20.1046 11 21 11.8954 21 13C21 13.8693 20.4449 14.6114 19.6668 14.8865C19.2672 15.0277 19 15.4055 19 15.8293V18H5V15.8293C5 15.4055 4.73284 15.0277 4.33325 14.8865C3.5551 14.6114 3 13.8693 3 13C3 11.8954 3.89543 11 5 11C6.10457 11 7 11.8954 7 13V16H9V15Z"></path></svg>
        </div>
        <div>Møbler</div>
    </button>
    
    <button class='category @(Selected == "Tøj" ? "active" : "")' @onclick='() => SelectCategory("Tøj")'>
        <div class="icon-wrap">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"width="18"height="18"><path d="M8.99805 3C8.99805 4.65685 10.3412 6 11.998 6C13.6549 6 14.998 4.65685 14.998 3H20.998C21.5503 3 21.998 3.44772 21.998 4V11C21.998 11.5523 21.5503 12 20.998 12H18.997L18.998 20C18.998 20.5523 18.5503 21 17.998 21H5.99805C5.44576 21 4.99805 20.5523 4.99805 20L4.99705 11.999L2.99805 12C2.44576 12 1.99805 11.5523 1.99805 11V4C1.99805 3.44772 2.44576 3 2.99805 3H8.99805ZM19.998 4.999H16.581L16.5642 5.04018C15.8115 6.7223 14.1566 7.91251 12.2149 7.99538L11.998 8C9.96331 8 8.21245 6.7846 7.43186 5.04018L7.41405 4.999H3.99805V9.999L6.9968 9.998L6.99705 19H16.998L16.9968 10L19.998 9.999V4.999Z"></path></svg>
        </div>
        <div>Tøj</div>
    </button>
    
    <button class='category @(Selected == "Kunst" ? "active" : "")' @onclick='() => SelectCategory("Kunst")'>
        <div class="icon-wrap">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"width="18"height="18"><path d="M15.5257 3.52562C16.8925 2.15878 19.1081 2.15878 20.475 3.52562C21.8415 4.89249 21.8417 7.10812 20.475 8.47487L20.3041 8.64675C20.1088 8.84201 20.1088 9.15852 20.3041 9.35379L20.475 9.52566C21.8415 10.8925 21.8417 13.1082 20.475 14.4749L20.3041 14.6468C20.1088 14.8421 20.1088 15.1586 20.3041 15.3538L20.475 15.5257C21.8415 16.8926 21.8417 19.1082 20.475 20.475C19.1082 21.8417 16.8926 21.8415 15.5257 20.475L15.3538 20.3041C15.1586 20.1088 14.8421 20.1088 14.6468 20.3041L14.4749 20.475C13.1082 21.8417 10.8925 21.8415 9.52566 20.475L9.35379 20.3041C9.15852 20.1088 8.84201 20.1088 8.64675 20.3041L8.47487 20.475C7.10812 21.8417 4.89249 21.8415 3.52562 20.475C2.15878 19.1081 2.15878 16.8925 3.52562 15.5257L3.69652 15.3538C3.8917 15.1587 3.89152 14.8421 3.69652 14.6468L3.52562 14.4749C2.15878 13.1081 2.15878 10.8925 3.52562 9.52566L3.69652 9.35379C3.8917 9.15861 3.89152 8.84204 3.69652 8.64675L3.52562 8.47487C2.15878 7.10803 2.15878 4.89247 3.52562 3.52562C4.89247 2.15878 7.10803 2.15878 8.47487 3.52562L8.64675 3.69652C8.84204 3.89152 9.15861 3.8917 9.35379 3.69652L9.52566 3.52562C10.8925 2.15878 13.1081 2.15878 14.4749 3.52562L14.6468 3.69652C14.8421 3.89152 15.1587 3.8917 15.3538 3.69652L15.5257 3.52562ZM19.0609 4.93969C18.4751 4.3539 17.5256 4.3539 16.9398 4.93969L16.7679 5.11157C15.7917 6.0874 14.209 6.08722 13.2327 5.11157L13.0608 4.93969C12.4751 4.3539 11.5255 4.3539 10.9397 4.93969L10.7679 5.11157C9.79171 6.0874 8.20894 6.08722 7.23268 5.11157L7.0608 4.93969C6.47501 4.3539 5.52548 4.3539 4.93969 4.93969C4.3539 5.52548 4.3539 6.47501 4.93969 7.0608L5.11157 7.23268C6.08722 8.20894 6.0874 9.79171 5.11157 10.7679L4.93969 10.9397C4.3539 11.5255 4.3539 12.4751 4.93969 13.0608L5.11157 13.2327C6.08722 14.209 6.0874 15.7917 5.11157 16.7679L4.93969 16.9398C4.3539 17.5256 4.3539 18.4751 4.93969 19.0609C5.52551 19.6464 6.4751 19.6466 7.0608 19.0609L7.23268 18.889C8.20892 17.9131 9.79162 17.9131 10.7679 18.889L10.9397 19.0609C11.5255 19.6464 12.4751 19.6466 13.0608 19.0609L13.2327 18.889C14.209 17.9131 15.7917 17.9131 16.7679 18.889L16.9398 19.0609C17.5256 19.6464 18.4752 19.6466 19.0609 19.0609C19.6466 18.4752 19.6464 17.5256 19.0609 16.9398L18.889 16.7679C17.9131 15.7917 17.9131 14.209 18.889 13.2327L19.0609 13.0608C19.6466 12.4751 19.6464 11.5255 19.0609 10.9397L18.889 10.7679C17.9131 9.79162 17.9131 8.20892 18.889 7.23268L19.0609 7.0608C19.6466 6.4751 19.6464 5.52551 19.0609 4.93969ZM14.5003 7.50026C15.6048 7.5004 16.5003 8.39578 16.5003 9.50027V14.5003C16.5002 15.6047 15.6047 16.5002 14.5003 16.5003H9.50027C8.39578 16.5003 7.5004 15.6048 7.50026 14.5003V9.50027C7.50026 8.3957 8.3957 7.50026 9.50027 7.50026H14.5003ZM9.50027 14.5003H14.5003V9.50027H9.50027V14.5003Z"></path></svg>
        </div>
        <div>Kunst</div>
    </button>
    
    <button class='category @(Selected == "Have" ? "active" : "")' 
            @onclick='() => SelectCategory("Have")'>
        <div class="icon-wrap">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor"width="18"height="18"><path d="M6 7C6 3.68629 8.68629 1 12 1C15.3137 1 18 3.68629 18 7C18 7.26214 17.9831 7.5207 17.9504 7.77457C19.77 8.80413 21 10.7575 21 13C21 16.3137 18.3137 19 15 19H13V22H11V19H8.5C5.46243 19 3 16.5376 3 13.5C3 11.2863 4.30712 9.37966 6.19098 8.50704C6.06635 8.02551 6 7.52039 6 7ZM7.00964 10.3319C5.82176 10.8918 5 12.1008 5 13.5C5 15.433 6.567 17 8.5 17H15C17.2091 17 19 15.2091 19 13C19 11.3056 17.9461 9.85488 16.4544 9.27234L15.6129 8.94372C15.7907 8.30337 16 7.67183 16 7C16 4.79086 14.2091 3 12 3C9.79086 3 8 4.79086 8 7C8 8.30783 8.6266 9.46903 9.60019 10.2005L8.39884 11.7995C7.85767 11.3929 7.38716 10.8963 7.00964 10.3319Z"></path></svg>
        </div>
        <div>Have</div>
    </button>

    
</div>

@code {
    [Parameter] public string Selected { get; set; } = "Alle";
    [Parameter] public EventCallback<string> SelectedChanged { get; set; }

    private async Task SelectCategory(string cat)
    {
        Selected = cat;
        await SelectedChanged.InvokeAsync(cat);
    }
}
</file>

<file path="Client/Components/Marked/MarkedGrid.razor">
@using Core

<div class="ads-grid">
    @if (Annoncer == null || !Annoncer.Any())
    {
        <p>Ingen annoncer at vise.</p>
    }
    else
    {
        @foreach (var a in Annoncer)
        {
            <MarkedComponent Annonce="a" />
        }
    }
</div>

@code {
    [Parameter] public IEnumerable<Annonce> Annoncer { get; set; }
}
</file>

<file path="Client/Components/AnnonceCard.razor">
@using Core

<div class="card m-2 p-3 shadow-sm border rounded position-relative d-flex flex-column justify-content-between"
     style="width: 260px; min-height: 420px;">
    
    <div class="flex-grow-1">
        <h4 class="mt-4">@Annonce.Title</h4>
        <p><strong>Pris:</strong> @Annonce.Price kr.</p>
        <p class="description">@Annonce.Description</p>
    </div>
    
    <div class="mt-auto pt-2 border-top">
        <p><strong>Kategori:</strong> @Annonce.Category</p>
        
    </div>
</div>


@code {
    [Parameter]
    public Annonce Annonce { get; set; }
}
</file>

<file path="Client/Layout/MainLayout.razor">
@inherits LayoutComponentBase
<div class="page">
    <div class="sidebar">
        <NavMenu/>
    </div>

    <main>
        <div class="top-row px-4 btn-primary" style="color: black">
            <NavLink class="nav-link" href="login">
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-door-open" viewBox="0 0 16 16">
                    <path d="M8.5 10c-.276 0-.5-.448-.5-1s.224-1 .5-1 .5.448.5 1-.224 1-.5 1"/>
                    <path d="M10.828.122A.5.5 0 0 1 11 .5V1h.5A1.5 1.5 0 0 1 13 2.5V15h1.5a.5.5 0 0 1 0 1h-13a.5.5 0 0 1 0-1H3V1.5a.5.5 0 0 1 .43-.495l7-1a.5.5 0 0 1 .398.117M11.5 2H11v13h1V2.5a.5.5 0 0 0-.5-.5M4 1.934V15h6V1.077z"/>
                </svg> Login
            </NavLink>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>
</file>

<file path="Client/Pages/MarkedDetailPage.razor">
@page "/annonce/{AnnonceId:int}"
@using Core
@inject HttpClient Http
@using Client.PW1
@using Client.Components.Marked

<MarkedDetailsComponent Annonce="@annonce"/>

@code {
    [Parameter] 
    public int AnnonceId { get; set; }
    
    private Annonce annonce = null;

    
    protected override async Task OnInitializedAsync()
    {
        annonce = await Http.GetFromJsonAsync<Annonce>($"http://localhost:{PASSWORD.localPort}/api/annonce/{AnnonceId}");
    }
}
</file>

<file path="Client/Service/IBrugerService.cs">
using Core;
namespace Client.Service
{
    public interface IBrugerService
    {
        Task<Bruger[]?> GetAll();
        Task Add(Bruger bruger);
        Task DeleteById(int id);
    }
}
</file>

<file path="Core/Bruger.cs">
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Core;
public class Bruger
{
    [BsonId]
    public int BrugerId { get; set; } 
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Phone { get; set; } 
    public string Address { get; set; }
    public string Password { get; set; }
}
</file>

<file path="Server/Controllers/BrugerController.cs">
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Core;
namespace Server.Controllers
{
    [ApiController]
    [Route("api/bruger")]
    public class BrugerController : ControllerBase
    {
        private IBrugerRepo brugerRepo;
        public BrugerController(IBrugerRepo brugerRepo)
        {
            this.brugerRepo = brugerRepo;
        }
        [HttpGet]
        public IEnumerable<Bruger> Get()
        {
            return brugerRepo.GetAll();
        }
        [HttpPost]
        public void Add(Bruger bruger)
        {
            brugerRepo.Add(bruger);
        }
        [HttpDelete]
        [Route("delete/{id:int}")]
        public void Delete(int id) 
        { 
            brugerRepo.Delete(id);
        }
        [HttpDelete]
        [Route("delete")]
        public void DeleteByQuery([FromQuery] int id)
        {
            brugerRepo.Delete(id);
        }
    }
}
</file>

<file path="Server/Repositories/AnnonceRepositoryMongoDb.cs">
using MongoDB.Driver;
using Core;
using Server.PW1;
namespace Server.Repositories;
public class AnnonceRepositoryMongoDb : IAnnonceRepository
{
    private readonly IMongoCollection<Annonce> aAnnonce;
    public AnnonceRepositoryMongoDb()
    {
        var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
        var client = new MongoClient(mongoUri);
        var database = client.GetDatabase("Genbrug");
        aAnnonce = database.GetCollection<Annonce>("Annonce");
    }
    public List<Annonce> GetAll()
    {
        return aAnnonce.Find(_  => true).ToList();
    }
    public void Add(Annonce annonce)
    {
        var lastAnnonce = aAnnonce
            .Find(Builders<Annonce>.Filter.Empty)
            .SortByDescending(a => a.AnonnceId)
            .Limit(1)
            .FirstOrDefault();
        annonce.AnonnceId = (lastAnnonce?.AnonnceId ?? 0) + 1;
        aAnnonce.InsertOne(annonce);
    }
}
</file>

<file path="Server/Repositories/IAnnonceRepository.cs">
using Core;
namespace Server.Repositories;
public interface IAnnonceRepository
{
    List<Annonce> GetAll();
    void Add(Annonce annonce);
}
</file>

<file path="Server/Repositories/IBrugerRepo.cs">
using System;
using Core;
namespace Server.Repositories
{
    public interface IBrugerRepo
    {
        Bruger[] GetAll();
        void Add(Bruger bruger);
        void Delete(int id);
    }
}
</file>

<file path="Client/Components/Marked/MarkedComponent.razor">
@using Core
@inject NavigationManager Nav

<article class="ad-card" @onclick="() => GotoDetailPage()">
    <div class="ad-media">
        <img src="@Annonce.ImageUrl" alt="Annonce billede" />
        <div class="price-badge">@Annonce.Price kr.</div>
    </div>

    <div class="ad-body">
        <div class="ad-meta">@Annonce.Location</div>
        <div class="ad-title">@Annonce.Title</div>
        @if (!string.IsNullOrWhiteSpace(Annonce.Description))
        {
            <p class="ad-desc">@Annonce.Description</p>
        }
    </div>

    <div class="ad-footer">
        <strong>Kategori:</strong> @Annonce.Category
    </div>
</article>
@code {
    [Parameter] public Annonce Annonce { get; set; }


    private Task GotoDetailPage()
    {
        var aid = Annonce.AnonnceId;
            Nav.NavigateTo($"annonce/{aid}");
            return Task.CompletedTask;
    }

}
</file>

<file path="Client/Service/BrugerServiceHttp.cs">
using System.Net.Http.Json;
using Core;
namespace Client.Service
{
    public class BrugerServiceHttp: IBrugerService
    {
        private HttpClient client;
        public BrugerServiceHttp(HttpClient client)
        { 
            this.client = client;
        }
        public async Task<Bruger[]?> GetAll()
        {
            return await client.GetFromJsonAsync<Bruger[]>($"{Server.Url}/api/bruger");
        }
        public async Task Add(Bruger bruger)
        {
            await client.PostAsJsonAsync($"{Server.Url}/api/bruger", bruger);
        }
        public async Task DeleteById(int id)
        {
            await client.DeleteAsync($"{Server.Url}/api/bruger/delete?id={id}");
        }
    }
}
</file>

<file path="Client/Service/Server.cs">
namespace Client.Service
{
    public class Server
    {
        public static string Url = "http://localhost:5044";
    }
}
</file>

<file path="Client/Program.cs">
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Client.Service;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IBrugerService, BrugerServiceHttp>();
await builder.Build().RunAsync();
</file>

<file path="Server/Repositories/BrugerRepo.cs">
using Core;
using MongoDB.Driver;
using Server.PW1;
namespace Server.Repositories
{
    public class BrugerRepo : IBrugerRepo
    {
        private readonly IMongoCollection<Bruger> brugerCollection;
        public BrugerRepo()
        {
            var mongoUri = $"mongodb+srv://tobiaskring111_db_user:{PASSWORD.superHemligPassword}@dbtest.adqud16.mongodb.net/";
            var client = new MongoClient(mongoUri);
            var db = client.GetDatabase("Genbrug");
            brugerCollection = db.GetCollection<Bruger>("brugere");
        }
        public void Add(Bruger item)
        {
            // Find højeste eksisterende BrugerId
            var lastUser = brugerCollection
                .Find(Builders<Bruger>.Filter.Empty)
                .SortByDescending(b => b.BrugerId)
                .Limit(1)
                .FirstOrDefault();
            item.BrugerId = (lastUser?.BrugerId ?? 0) + 1;
            brugerCollection.InsertOne(item);
        }
        public void Delete(int id)
        {
            brugerCollection.DeleteOne(b => b.BrugerId == id);
        }
        public Bruger[] GetAll()
        {
            return brugerCollection.Find(Builders<Bruger>.Filter.Empty).ToList().ToArray();
        }
    }
}
</file>

<file path="Client/Pages/OpretBruger.razor">
@page "/addbruger"
@using Client.Service
@using Core
@inject HttpClient http
@inject NavigationManager navMan
@inject IBrugerService brugerService

<PageTitle>Add User</PageTitle>

<h3>Add User</h3>

<EditForm Model="@_bruger" class="row p-3" OnValidSubmit="@HandleValidSubmit">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div class="col-md-12 mb-3">
        <label for="Name">Name:</label>
        <InputText id="Name" @bind-Value="_bruger.Name" class="form-control" placeholder="Navn"/>
    </div>
    <div class="col-md-12 mb-3">
        <label for="Email">Email:</label>
        <InputText id="Email" @bind-Value="_bruger.Email" class="form-control" placeholder="Email"/>
    </div>
    <div class="col-md-12 mb-3">
        <label for="pwd">Adgangskode:</label>
        <InputText id="pwd"
                   type="@PasswordType"
                   class="form-control"
                   @bind-Value="_bruger.Password"
                   placeholder="Adgangskode"/>
        <i class="bi bi-eye" @onclick="ToggleAdgangskodeVisibility"></i>
    </div>
    <div class="col-md-12 mb-3">
        <label for="Phone">Telefon nummer:</label>
        <InputText id="Phone" @bind-Value="_bruger.Phone" class="form-control" placeholder="Telefon nummer"/>
    </div>

    <div class="col-md-12 mb-3">
        <label for="Adress">Adresse:</label>
        <InputText id="Adress" @bind-Value="_bruger.Address" class="form-control" placeholder="Adresse"/>
    </div>

    <div class="col-12 mb-3">
        <button type="submit" class="btn btn-primary">Create</button>
    </div>
</EditForm>


@code {
    Bruger _bruger = new();
    
    public async Task HandleValidSubmit()
    {
        // await http.PostAsJsonAsync("", _bike);
        await brugerService.Add(_bruger);
        _bruger = new(); // clear fields in form
        navMan.NavigateTo("bruger");

    }
    
    private string PasswordType => visPassword ? "text" : "password";
    private bool visPassword = false;

    private void ToggleAdgangskodeVisibility() => visPassword = !visPassword;

}
</file>

<file path="Server/Controllers/AnnonceController.cs">
using Core;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
namespace Server.Controllers;
    [ApiController]
    [Route("api/annonce")]
    public class AnnonceController : ControllerBase
    {
        private IAnnonceRepository aAnnonce;
        public AnnonceController(IAnnonceRepository aAnnonce)
        {
            this.aAnnonce = aAnnonce;
        }
        [HttpPost]
        public void Add(Annonce annonce) 
        {
            aAnnonce.Add(annonce);
        }
        [HttpGet]
        public IEnumerable<Annonce> GetAll() 
        { 
            return aAnnonce.GetAll();
        }
        [HttpGet("{id}")]
        public Annonce GetById(int id)
        {
            return GetAll().Where(a => a.AnonnceId == id).ToList()[0];
        }
    }
</file>

<file path="Client/Layout/NavMenu.razor">
@using Core



<div class="top-row ps-3 navbar navbar-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="">Mini projekt</a>
        <button title="Navigation menu" class="navbar-toggler" @onclick="ToggleNavMenu">
            <span class="navbar-toggler-icon"></span>
        </button>
    </div>
</div>

<div class="@NavMenuCssClass nav-scrollable" @onclick="ToggleNavMenu">
    <nav class="nav flex-column h-100">
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="marked" Match="NavLinkMatch.All">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-shop" viewBox="0 0 16 16">
                    <path d="M2.97 1.35A1 1 0 0 1 3.73 1h8.54a1 1 0 0 1 .76.35l2.609 3.044A1.5 1.5 0 0 1 16 5.37v.255a2.375 2.375 0 0 1-4.25 1.458A2.37 2.37 0 0 1 9.875 8 2.37 2.37 0 0 1 8 7.083 2.37 2.37 0 0 1 6.125 8a2.37 2.37 0 0 1-1.875-.917A2.375 2.375 0 0 1 0 5.625V5.37a1.5 1.5 0 0 1 .361-.976zm1.78 4.275a1.375 1.375 0 0 0 2.75 0 .5.5 0 0 1 1 0 1.375 1.375 0 0 0 2.75 0 .5.5 0 0 1 1 0 1.375 1.375 0 1 0 2.75 0V5.37a.5.5 0 0 0-.12-.325L12.27 2H3.73L1.12 5.045A.5.5 0 0 0 1 5.37v.255a1.375 1.375 0 0 0 2.75 0 .5.5 0 0 1 1 0M1.5 8.5A.5.5 0 0 1 2 9v6h1v-5a1 1 0 0 1 1-1h3a1 1 0 0 1 1 1v5h6V9a.5.5 0 0 1 1 0v6h.5a.5.5 0 0 1 0 1H.5a.5.5 0 0 1 0-1H1V9a.5.5 0 0 1 .5-.5M4 15h3v-5H4zm5-5a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v3a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1zm3 0h-2v3h2z"/>
                </svg> Marked
            </NavLink>
        </div>
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="annoncer">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-view-list" viewBox="0 0 16 16">
                    <path d="M3 4.5h10a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-3a2 2 0 0 1 2-2m0 1a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1zM1 2a.5.5 0 0 1 .5-.5h13a.5.5 0 0 1 0 1h-13A.5.5 0 0 1 1 2m0 12a.5.5 0 0 1 .5-.5h13a.5.5 0 0 1 0 1h-13A.5.5 0 0 1 1 14"/>
                </svg> Mine annoncer
            </NavLink>
        </div>
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="indkøb">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-receipt-cutoff" viewBox="0 0 16 16">
                    <path d="M3 4.5a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 1 1 0 1h-6a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5m0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5M11.5 4a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1zm0 2a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1zm0 2a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1zm0 2a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1zm0 2a.5.5 0 0 0 0 1h1a.5.5 0 0 0 0-1z"/>
                    <path d="M2.354.646a.5.5 0 0 0-.801.13l-.5 1A.5.5 0 0 0 1 2v13H.5a.5.5 0 0 0 0 1h15a.5.5 0 0 0 0-1H15V2a.5.5 0 0 0-.053-.224l-.5-1a.5.5 0 0 0-.8-.13L13 1.293l-.646-.647a.5.5 0 0 0-.708 0L11 1.293l-.646-.647a.5.5 0 0 0-.708 0L9 1.293 8.354.646a.5.5 0 0 0-.708 0L7 1.293 6.354.646a.5.5 0 0 0-.708 0L5 1.293 4.354.646a.5.5 0 0 0-.708 0L3 1.293zm-.217 1.198.51.51a.5.5 0 0 0 .707 0L4 1.707l.646.647a.5.5 0 0 0 .708 0L6 1.707l.646.647a.5.5 0 0 0 .708 0L8 1.707l.646.647a.5.5 0 0 0 .708 0L10 1.707l.646.647a.5.5 0 0 0 .708 0L12 1.707l.646.647a.5.5 0 0 0 .708 0l.509-.51.137.274V15H2V2.118z"/>
                </svg> Mine indkøb
            </NavLink>
        </div>

        

        <div class="nav-item px-3 mt-auto">
            <NavLink class="nav-link" href="addbruger">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-door-closed" viewBox="0 0 16 16">
                    <path d="M3 2a1 1 0 0 1 1-1h8a1 1 0 0 1 1 1v13h1.5a.5.5 0 0 1 0 1h-13a.5.5 0 0 1 0-1H3zm1 13h8V2H4z" />
                    <path d="M9 9a1 1 0 1 0 2 0 1 1 0 0 0-2 0" />
                </svg> Opret Bruger
            </NavLink>
        </div>
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="logout">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-door-closed" viewBox="0 0 16 16">
                    <path d="M3 2a1 1 0 0 1 1-1h8a1 1 0 0 1 1 1v13h1.5a.5.5 0 0 1 0 1h-13a.5.5 0 0 1 0-1H3zm1 13h8V2H4z"/>
                    <path d="M9 9a1 1 0 1 0 2 0 1 1 0 0 0-2 0"/>
                </svg> Log out
            </NavLink>
        </div>
    </nav>
</div>




@code {
    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}
</file>

<file path="Core/Annonce.cs">
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Core;
public class Annonce
{
    [BsonId]
    public int AnonnceId { get; set; }
    public int BrugerId { get; set; }
    public string? Title { get; set; } 
    public string? Description { get; set; } 
    public double Price { get; set; }
    public string? Category { get; set; } 
    public string? Status { get; set; } 
    public string? ImageUrl { get; set; } 
    public int SælgerId { get; set; }
    public string? Location { get; set; } 
    public List<Anmodning>? Anmodninger { get; set; }
}
</file>

<file path="Server/Program.cs">
using Microsoft.Extensions.Options;
using Server.Repositories;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddSingleton<IAnnonceRepository, AnnonceRepositoryMongoDb>();
builder.Services.AddSingleton<IBrugerRepo, BrugerRepo>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
//app.UseHttpsRedirection();
app.UseCors("policy");
app.UseAuthorization();
app.MapControllers();
app.Run();
</file>

<file path="Client/Pages/MineAnnoncerPage.razor">
@page "/annoncer"
@using Client.PW1
@inject NavigationManager Nav
@using Client.Components
@using Core;
@inject HttpClient http


<h3>Mine annoncer</h3>
@if (annoncer.Count == 0 )
{
	<p>No products</p>
}
else
{
	<div class="d-flex flex-wrap">
		@foreach(var p in annoncer)
		{
			<AnnonceCard Annonce="p"/>
		}
	</div>
}
<button class="btn btn-primary" @onclick="GoToTilføjAnnoncePage"> 
	Opret Ny Annonce
</button>

@code {

	private List<Annonce> annoncer = new();

	protected override async Task OnInitializedAsync()
	{
		annoncer = await http.GetFromJsonAsync<List<Annonce>>($"http://localhost:{PASSWORD.localPort}/api/annonce");
	}
	
	void GoToTilføjAnnoncePage()
	{
		Nav.NavigateTo("/TilføjAnnonce");
	}


}
</file>

<file path="Client/Pages/MarkedPage.razor">
@page "/marked"
@inject NavigationManager NavMan
@inject HttpClient Http
@using Core
@using Client.Components.Marked;
@using Client.PW1


<div class="container-xl">
  <header class="hero">

    <div class="search-wrap">
      <div class="searchbox">
        <input placeholder="Søg efter produkt" />
        <button class="search-btn" aria-label="Søg">
          <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <circle cx="11" cy="11" r="6"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line>
          </svg>
        </button>
      </div>
    </div>
    <MarkedFilter Selected="@SelectedCategory" SelectedChanged="OnCategoryChanged" />
  </header>

  
  <section>
    <h3 style="max-width:1160px;margin:18px auto 8px">Annoncer</h3>

    @if (Annoncer.Count == 0)
    {
      <p>No products</p>
    }
    else
    {
      <MarkedGrid Annoncer="@Annoncer" />
    }
      
   
  </section>
</div>

@code {
    private string search = "";
    private string SelectedCategory { get; set; } = "Alle";

    private List<Annonce> Annoncer = new();

    protected override async Task OnInitializedAsync()
    {
      Annoncer = await Http.GetFromJsonAsync<List<Annonce>>($"http://localhost:{PASSWORD.localPort}/api/annonce");
    }
    
    IEnumerable<Annonce> FilteredAnnoncer => SelectedCategory == "Alle"
      ? Annoncer
      : Annoncer.Where(a => string.Equals(a.Category, SelectedCategory, StringComparison.OrdinalIgnoreCase));

    private void OnCategoryChanged(string cat)
    {
      SelectedCategory = cat;
    }
    
    /*private List<Annonce> Annoncer = new()
    {
      new Annonce
      {
        AnonnceId = 1,
        Title = "GO PRIS FOR HURTIG HANDEL. 2 IKEA Småstad...",
        Description = "Kort beskrivelse — stand, mål eller andet.",
        ImageUrl = "https://m.media-amazon.com/images/I/91TjRnsruRL._AC_UF350,350_QL80_.jpg",
        Price = 800,
        Category = "Møbler",
        Status = "Aktiv",
        SælgerId = 3,
        BrugerId = 3,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      },
      new Annonce
      {
        AnonnceId = 2,
        Title = "Komplet sort stålskorssten rør og tilbehør",
        Description = "Kort beskrivelse.",
        ImageUrl = "https://jyskpejsecenter.dk/wp-content/uploads/2024/10/5.jpg",
        Price = 5300,
        Category = "Have",
        Status = "Aktiv",
        SælgerId = 4,
        BrugerId = 4,
        Location = "SH-A1.06"
      }
    };*/
}
</file>

</files>
