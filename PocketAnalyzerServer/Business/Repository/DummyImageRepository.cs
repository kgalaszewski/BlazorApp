using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Repository;

public class DummyImageRepository : IDummyImageRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DummyImageRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateDummyImage(DummyImage image)
    {
        var createdId = (await _dbContext.DummyImages.AddAsync(image)).Entity.Id;
        await _dbContext.SaveChangesAsync();
        return createdId;
    }

    public async Task<IEnumerable<DummyImage>> GetAllDummyImagesForDummy(int dummyId)
    {
        return await _dbContext.DummyImages
            .Where(image => image.DummyId == dummyId)
            .ToListAsync();
    }

    public async Task DeleteDummyImage(int dummyImageId)
    {
        var imageToDelete = await _dbContext.DummyImages.FindAsync(dummyImageId);
        if (imageToDelete is not null)
        {
            _dbContext.DummyImages.Remove(imageToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteAllDummyImages(int dummyId)
    {
        var dummysImages = _dbContext.DummyImages
            .Where(image => image.DummyId == dummyId);
        _dbContext.DummyImages.RemoveRange(dummysImages);
        await _dbContext.SaveChangesAsync();
    }
}
