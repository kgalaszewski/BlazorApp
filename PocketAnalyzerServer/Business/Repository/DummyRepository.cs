using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository;

public class DummyRepository : IDummyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DummyRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Dummy> CreateDummyAsync(Dummy dummy)
    {
        try
        {
            var createdDummy = (await _dbContext.Dummies.AddAsync(dummy)).Entity;
            await _dbContext.SaveChangesAsync();
            return createdDummy;
        }
        catch (Exception ex)
        {
            throw new Exception($"ex msg : {ex.Message}\nex: {ex}");
        }
    }

    public async Task<IEnumerable<Dummy>> GetAllDummiesAsync()
    {
        try
        {
            return await _dbContext.Dummies
                .Include(dummy => dummy.DummyImages)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"ex msg : {ex.Message}\nex: {ex}");
        }
    }

    public async Task<Dummy> GetDummyAsync(int id)
    {
        try
        {
            return await _dbContext.Dummies
                .Include(dummy => dummy.DummyImages)
                .FirstOrDefaultAsync(dummy => dummy.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception($"ex msg : {ex.Message}\nex: {ex}");
        }
    }

    public async Task<Dummy> UpdateDummyAsync(int dummyId, Dummy newDummyState)
    {
        try
        {
            var dummy = await _dbContext.Dummies.FindAsync(dummyId);
            dummy.Name = newDummyState.Name;
            dummy.Value = newDummyState.Value;
            var updatedDummy = _dbContext.Dummies.Update(dummy).Entity;
            await _dbContext.SaveChangesAsync();
            return updatedDummy;
        }
        catch (Exception ex)
        {
            throw new Exception($"ex msg : {ex.Message}\nex: {ex}");
        }
    }

    public async Task<bool> DeleteDummyAsync(int dummyId)
    {
        try
        {
            var dummy = await _dbContext.Dummies.FindAsync(dummyId);
            _dbContext.Dummies.Remove(dummy);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception($"ex msg : {ex.Message}\nex: {ex}");
        }
    }
}
