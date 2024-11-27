using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromitelApiSample.src.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ProductRequest
    {
        [Newtonsoft.Json.JsonProperty("produktID", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<int> ProduktID { get; set; }

        [Newtonsoft.Json.JsonProperty("kategoriaID", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<int> KategoriaID { get; set; }

        [Newtonsoft.Json.JsonProperty("indexKatalogowy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object IndexKatalogowy { get; set; }

        [Newtonsoft.Json.JsonProperty("indexHandlowy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object IndexHandlowy { get; set; }

        [Newtonsoft.Json.JsonProperty("rodzaj", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object Rodzaj { get; set; }

        [Newtonsoft.Json.JsonProperty("producent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object Producent { get; set; }

        [Newtonsoft.Json.JsonProperty("nazwa", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Nazwa { get; set; }

        [Newtonsoft.Json.JsonProperty("nazwaOryginalna", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NazwaOryginalna { get; set; }

        [Newtonsoft.Json.JsonProperty("stanWiekszyRownyNiz", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? StanWiekszyRownyNiz { get; set; }

    }
}
