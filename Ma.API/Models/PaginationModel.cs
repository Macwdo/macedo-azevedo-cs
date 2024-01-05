namespace Ma.API.Models;

public class PaginationModel<T>(
    IEnumerable<T> Items,
    PaginationInfo PaginationInfo
);
