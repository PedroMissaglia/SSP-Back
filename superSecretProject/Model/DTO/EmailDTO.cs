using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Model.DTO
{
    public class EmailDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
