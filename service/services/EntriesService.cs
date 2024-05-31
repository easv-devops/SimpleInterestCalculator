using Entities;
using infrastructure;
using Service.interfaces;

namespace Service;

public class EntriesService : IEntriesService
{
    private readonly EntriesRepository _repository;

    public EntriesService(EntriesRepository repository)
    {
        _repository = repository;
    }

    public bool AddEntry(Entries entry)
    {
        return _repository.AddEntry(entry);
    }

    public bool DeleteEntry(int entryId)
    {
        return _repository.DeleteEntryByEntryId(entryId);
    }

    public Entries GetEntryByEntryId(int entryId)
    {
        return _repository.GetEntryByEntryId(entryId);
    }

    public List<Entries> GetEntriesByUserId(int userId)
    {
        return _repository.GetEntriesByUserId(userId);
    }
}