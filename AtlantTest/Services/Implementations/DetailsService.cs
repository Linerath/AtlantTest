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

        public void DeleteDetail(int detailId)
        {
            detailRepository.Delete(detailId);
        }

        public IEnumerable<Detail> GetAllDetails()
        {
            return detailRepository.GetAll();
        }

        public DetailsModel GetAllDetailsData()
        {
            var model = new DetailsModel
            {
                Storekeepers = storekeeperRepository.GetAll()
            };

            var allDetails = detailRepository.GetAll();
            List<DetailModel> detailsData = new List<DetailModel>();

            foreach (var detailData in allDetails)
            {
                detailsData.Add(new DetailModel
                {
                    Detail = detailData,
                    Storekeeper = storekeeperRepository.Get(detailData.StorekeeperId),
                });
            }

            model.DetailsData = detailsData;

            return model;
        }


    }
}