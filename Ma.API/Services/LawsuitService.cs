using Ma.API.Entities.Lawsuit;
using Ma.API.Repository;

namespace Ma.API.Services;

public class LawsuitService: ILawsuitService
{
    private readonly IRepository<Lawsuit> _repository;
    private readonly ILogger<LawsuitService> _logger;

    public LawsuitService(ILogger<LawsuitService> logger, IRepository<Lawsuit> repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public IEnumerable<Lawsuit> GetLawsuits()
    {
        return _repository.Get();
    }

    public Lawsuit? GetLawsuit(int id)
    {
        return _repository.Get(id);
    }

    public Lawsuit CreateLawsuit(Lawsuit lawsuit)
    {
        return _repository.Create(lawsuit);
    }

    public Lawsuit UpdateLawsuit(Lawsuit lawsuit, Lawsuit lawsuitToUpdate)
    {

        return _repository.Update(lawsuit);
    }

    public void DeleteLawsuit(Lawsuit lawsuit)
    {
        _repository.Delete(lawsuit);
    }




}