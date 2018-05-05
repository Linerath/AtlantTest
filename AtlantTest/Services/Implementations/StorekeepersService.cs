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
                models.Add(new StorekeepersModel
                {
                    Storekeeper = storekeeper,
                    DetailsQuantity = detailRepository.GetByStorekeeperId(storekeeper.Id).Quantity
                });
            }

            return models;
        }
    }
}