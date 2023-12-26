using Ma.API.Data;
using Ma.API.Entities;
using Ma.API.Entities.Lawsuit;
using Ma.API.Exceptions;
using Ma.API.Repository;

namespace Ma.API.Services;

public class LawsuitService
{
    private readonly IRepository<Lawsuit> _lawsuitRepository;
    private readonly ILogger<LawsuitService> _logger;

    public LawsuitService(
        ILogger<LawsuitService> logger,
        IRepository<Lawsuit> lawsuitRepository
        )

    {
        _logger = logger;
        _lawsuitRepository = lawsuitRepository;
    }

    public async Lawsuit? Get(int id)
    {
        return _lawsuitRepository.Get(id);

    }



}