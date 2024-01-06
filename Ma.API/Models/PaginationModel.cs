namespace Ma.API.Models;

public class PaginationModel<T>
{
    public int Skip { get; set; }
    public int Take { get; set; }
    public int Total { get; set; }

    public IEnumerable<T> Data {get; set;}

    public PaginationModel(IEnumerable<T> data, int skip, int take, int total)
    {
        Data = data;
        Skip = skip;
        Take = take;
        Total = total;
    }
}

