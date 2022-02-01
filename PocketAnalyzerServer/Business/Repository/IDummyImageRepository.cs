using DataAccess.Models;

namespace Business.Repository;

public interface IDummyImageRepository
{
    public Task<int> CreateDummyImage(DummyImage image);
    public Task DeleteDummyImage(int dummyImageId);
    public Task DeleteAllDummyImages(int dummyId);
    public Task<IEnumerable<DummyImage>> GetAllDummyImagesForDummy(int dummyId);
}