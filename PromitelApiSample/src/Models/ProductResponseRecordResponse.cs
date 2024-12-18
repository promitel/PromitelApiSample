﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromitelApiSample.src.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ProductResponseRecordResponse
    {
        [Newtonsoft.Json.JsonProperty("strona", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Strona { get; set; }

        [Newtonsoft.Json.JsonProperty("sumaStron", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SumaStron { get; set; }

        [Newtonsoft.Json.JsonProperty("rekordyStronaBiezaca", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RekordyStronaBiezaca { get; set; }

        [Newtonsoft.Json.JsonProperty("rekordowNaStronie", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RekordowNaStronie { get; set; }

        [Newtonsoft.Json.JsonProperty("sumaWszystichRekordow", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SumaWszystichRekordow { get; set; }

        [Newtonsoft.Json.JsonProperty("rekordy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<ProductResponse> Rekordy { get; set; }

    }

}
