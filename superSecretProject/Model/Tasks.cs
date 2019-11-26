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
        public Tasks()
        {
            Users = new HashSet<Users>();
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }
   
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("date")]
        public DateTime date { get; set; }

        [Required]
        [JsonProperty("time")]
        public DateTime time { get; set; }


        [JsonProperty("userId")]
        public Guid userId { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
