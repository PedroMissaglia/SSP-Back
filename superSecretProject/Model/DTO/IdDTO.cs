using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superSecretProject.Model.DTO
{
    public class IdDTO
    {

        public IdDTO(Guid item)
        {
            this.Id = item;
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
