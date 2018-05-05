using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtlantTest.Entities;
using AtlantTest.Models;
using AtlantTest.Repositories;

namespace AtlantTest.Services.Implementations
{
    public class DetailsService : IDetailsService
    {
        private IStorekeeperRepository storekeeperRepository;
        private IDetailRepository detailRepository;

        public DetailsService(IStorekeeperRepository storekeeperRepository, IDetailRepository detailRepository)
        {
            this.storekeeperRepository = storekeeperRepository;
            this.detailRepository = detailRepository;
        }

        public void Add(Detail detail)
        {
            detailRepository.Add(detail);
        }

        public IEnumerable<Detail> GetAllDetails()
        {
            return detailRepository.GetAll();
        }

        public IEnumerable<DetailModel> GetAllDetailsData()
        {
            var details = detailRepository.GetAll();

            List<DetailModel> models = new List<DetailModel>();
            foreach (var detail in details)
            {
                models.Add(new DetailModel
                {
                    Detail = detail,
                    Storekeeper = storekeeperRepository.Get(detail.StorekeeperId),
                });
            }

            return models;
        }


    }
}