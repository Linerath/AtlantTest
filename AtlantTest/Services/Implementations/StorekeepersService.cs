using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtlantTest.Entities;
using AtlantTest.Models;
using AtlantTest.Repositories;

namespace AtlantTest.Services.Implementations
{
    public class StorekeepersService : IStorekeepersService
    {
        private IStorekeeperRepository storekeeperRepository;
        private IDetailRepository detailRepository;

        public StorekeepersService(IStorekeeperRepository storekeeperRepository, IDetailRepository detailRepository)
        {
            this.storekeeperRepository = storekeeperRepository;
            this.detailRepository = detailRepository;
        }

        public void AddStorekeeper(Storekeeper storekeeper)
        {
            storekeeperRepository.Add(storekeeper);
        }

        public IEnumerable<Storekeeper> GetAllStorekeepers()
        {
            return storekeeperRepository.GetAll();
        }

        public IEnumerable<StorekeepersModel> GetAllStorekeepersData()
        {
            var storekeepers = storekeeperRepository.GetAll();

            List<StorekeepersModel> models = new List<StorekeepersModel>();
            foreach (var storekeeper in storekeepers)
            {
                var detail = detailRepository.GetByStorekeeperId(storekeeper.Id);
                int quantity = detail != null ? detail.Quantity : 0;
                models.Add(new StorekeepersModel
                {
                    Storekeeper = storekeeper,
                    DetailsQuantity = quantity
                });
            }

            return models;
        }
    }
}