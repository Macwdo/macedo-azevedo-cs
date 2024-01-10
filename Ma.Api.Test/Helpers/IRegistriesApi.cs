using Ma.API.Models.Registry;
using Refit;

namespace Ma.Api.Test.Helpers;

public interface IRegistriesApi
{

    [Get(EndpointsHelper.RegistriesEndpoint + "{id}")]
    Task<ApiResponse<ReadRegistryDto>> GetRegistryAsync(int id);

    [Get(EndpointsHelper.RegistriesEndpoint)]
    Task<ApiResponse<IEnumerable<ReadRegistryDto>>> GetRegistriesAsync();


    [Post(EndpointsHelper.RegistriesEndpoint)]
    Task<ApiResponse<ReadRegistryDto>> CreateRegistryAsync([Body] CreateRegistryDto registryDto);

}