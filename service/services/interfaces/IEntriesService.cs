using Entities;

namespace Service.interfaces;

public interface IEntriesService
{
    public bool AddEntry(Entries entry);
    public bool DeleteEntry(int entryId);
    public Entries GetEntryByEntryId(int entryId);
    public List<Entries> GetEntriesByUserId(int userId);
}