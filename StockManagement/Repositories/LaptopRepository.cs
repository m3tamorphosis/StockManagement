﻿namespace StockManagement
{
    public class LaptopRepository : IStockRepository<Laptop>
    {
        
        private List<Laptop> _laptops;

        public LaptopRepository()
        {
            _laptops = new List<Laptop>()
            {
                new Laptop()
                {Name= "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512}
            };
        }
        public Laptop Add(Laptop item)
        {
            _laptops.Add(item);
            return GetById(item.Id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _laptops.Remove(item);
            }
        }

        public IEnumerable<Laptop> GetAll()
        {
            return _laptops;
        }

        public Laptop GetById(int id)
        {
            return _laptops.FirstOrDefault(x => x.Id == id);
        }


        public Laptop? Update(Laptop laptop)
        {
            var item = GetById(laptop.Id);
            if (item != null)
            {
                item.Name = laptop.Name;
                item.Quantity = laptop.Quantity;
                item.Price = laptop.Price;
                item.ScreenSize = laptop.ScreenSize;
                item.Storage = laptop.Storage;
                item.Ram = laptop.Ram;


                return item;

            }
            return null;
        }
    }
}