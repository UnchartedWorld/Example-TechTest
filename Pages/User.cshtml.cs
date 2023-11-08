using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.DTOs;
using System.Net;
using System.Text.Json;

namespace MotivWebApp.Pages
{
    public class UserModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public string RandomUserApiURL => _configuration["UserInfo:RandomDataURL"];
        public UserResponse UserResponseData { get; set; }

        public UserModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // The idea to get the info came from here: https://makolyte.com/csharp-examples-of-using-jsondocument-to-read-json/
        public async Task OnGet()
        {
            HttpClient? client = new();

            string? responseMessage = await client.GetStringAsync(RandomUserApiURL);
            JsonElement data = JsonDocument.Parse(responseMessage).RootElement.GetProperty("results")[0];

            JsonElement nameData = data.GetProperty("name");
            DateTime dataDoB = DateTime.Parse(data.GetProperty("dob").GetProperty("date").GetString());

            UserResponseData = new UserResponse()
            {
                NameTitle = nameData.GetProperty("title").GetString(),
                Name = $"{nameData.GetProperty("first").GetString()} {nameData.GetProperty("last").GetString()}",
                PictureURL = data.GetProperty("picture").GetProperty("large").GetString(),
                Email = data.GetProperty("email").GetString(),
                DateOfBirth = dataDoB.ToString("dd/MM/yyyy")
            };

        }
    }
}
