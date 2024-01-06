using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Ma.API.Models;

public class PaginationModel<T>
{
    [JsonProperty("skip")]
    [JsonPropertyName("skip")]
    public int Skip { get; set; }
    
    [JsonProperty("take")]
    [JsonPropertyName("take")]
    public int Take { get; set; }
    
    [JsonProperty("total")]
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonProperty("result")]
    [JsonPropertyName("result")]
    public IEnumerable<T> Result {get; set;}

    public PaginationModel(IEnumerable<T> result, int skip, int take, int total)
    {
        Result = result;
        Skip = skip;
        Take = take;
        Total = total;
    }
}

