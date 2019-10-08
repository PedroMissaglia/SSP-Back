using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Model
{
    public class Autenticacao
    {
        public Autenticacao()
        {
            Users = new HashSet<Users>();
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty("numero")]
        public string Numero { get; set; }

        [Required]
        [JsonProperty("Nivel")]
        public string Nivel { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
