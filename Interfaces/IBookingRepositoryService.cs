using netcore1stapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore1stapi.Interfaces
{
    public interface IBookingRepositoryService
    {
        IEnumerable<Item> GetAll();
        void Add(Item value);
        Item Get(int id);
        void Update(int id, Item value);
        void Delete(int id);

    }
}
