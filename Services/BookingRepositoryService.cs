using netcore1stapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore1stapi.Models;

namespace netcore1stapi.Services
{
    public class BookingRepositoryService : IBookingRepositoryService
    {
        private List<Item> items = new List<Item> { new Item { Id = 1, Name = "you guess", IsChecked = true } };

        public void Add(Item value)
        {
            items.Add(value);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Item> GetAll()
        {
            return items;
        }

        public void Update(int id, Item value)
        {
            throw new NotImplementedException();
        }
    }
}
