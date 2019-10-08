using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexandria.Model.DTO
{
    public class UsersUpdateDTO
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
