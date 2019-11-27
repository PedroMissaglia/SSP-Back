using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Model
{
    public class Tasks
    {
        
        [JsonProperty("id")]
        public Guid Id { get; set; }
   
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("usersId")]
        public Guid UsersId { get; set; }
        

        

    }
}
