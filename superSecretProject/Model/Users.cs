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
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [Required]
        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }


        [JsonProperty("autenticacaoId")]
        public Guid? AutenticacaoId { get; set; }

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; }


    }
}
