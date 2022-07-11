using Refit;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Desafio.AMcom.Model
{
    public record UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }

    public record PageUsersModel
    {
        [JsonPropertyName("data")]
        public IEnumerable<UserModel> Users { get; set; }
    }
}
