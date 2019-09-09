using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Model
{
    public class Users
    {
        
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [Required]
        [JsonProperty("nome")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("senha")]
        public string Senha { get; set; }

        [Required]
        [JsonProperty("tipo")]
        public string Tipo { get; set; }


    }
}
