using Ma.API.Entities.Lawsuit;

namespace Ma.API.Services;

public interface ILawsuitService
{
    IEnumerable<Lawsuit> GetLawsuits();
    Lawsuit? GetLawsuit(int id);
    Lawsuit CreateLawsuit(Lawsuit lawsuit);
    Lawsuit UpdateLawsuit(Lawsuit lawsuit, Lawsuit lawsuitToUpdate);
    void DeleteLawsuit(Lawsuit lawsuit);
}