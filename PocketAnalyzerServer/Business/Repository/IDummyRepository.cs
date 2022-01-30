using DataAccess.Models;

namespace Business.Repository;

public interface IDummyRepository
{
    public Task<Dummy> CreateDummyAsync(Dummy dummy);
    public Task<IEnumerable<Dummy>> GetAllDummiesAsync();
    public Task<Dummy> GetDummyAsync(int id);
    public Task<Dummy> UpdateDummyAsync(int dummyId, Dummy newDummyState);
    public Task<bool> DeleteDummyAsync(int dummyId);
}
