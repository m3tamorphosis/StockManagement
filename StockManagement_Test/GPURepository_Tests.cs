using Moq;
using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test
{
    public class GPURepository_Tests
    {
        // Create
        [Test]
        public void AddGPU()
        {
            // Arrange
            var GPURepo = new GPURepository();
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            // Act
            GPURepo.Add(newGPU);
            // Assert
            Assert.That(GPURepo.GetAll(), Does.Contain(newGPU));
        }

        // Read
        [Test]
        public void ReadGPU()
        {
            // Arrange
            var GPURepo = new GPURepository();
            // Act
            var result = GPURepo.GetAll();
            // Assert
            Assert.That(result, Is.Not.Null);
        }
        
        // Update
        [Test]
        public void Update()
        {
            // Arrange
            var GPURepo = new GPURepository();
            GPU newGPU = new GPU() { Name = "GTX1660", Quantity = 1, Price = 209.99m, Vram = 6, Cuda = 1408 };
            var newId = GPURepo.Add(newGPU);
            GPU updated = new GPU() { Name = "Nvidia GTX 950", Quantity = 5, Price = 209.99m, Vram = 2, Cuda = 768 };
            // Act
            var result = GPURepo.Update(newId);
            // Assert
            Assert.That(result.Id, Is.EqualTo(newId.Id));
        }

        // Delete
        [Test]
        public void Delete()
        {
            // Arrange
            var GPURepo = new GPURepository();
            GPU newGPU = new GPU() { Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            var newId = GPURepo.Add(newGPU).Id;
            // Act
            GPURepo.Delete(newId);
            // Assert
            Assert.That(GPURepo.GetAll().Any(x => x.Id != newId));
        }



    }
}