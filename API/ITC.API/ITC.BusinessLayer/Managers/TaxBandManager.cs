using AutoMapper;
using ITC.BusinessLayer.Managers.Interfaces;
using ITC.BusinessLayer.Models;
using ITC.DataAccess.Entities;
using ITC.DataAccess.Interfaces;
using ITC.DataAccess.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITC.BusinessLayer.Managers
{
    public class TaxBandManager : ITaxBandManager
    {
        private readonly IGenericRepository<TaxBand> _taxBandRepository;
        private readonly IMapper _mapper;

        public TaxBandManager(IUnitOfWork uof, IMapper mapper)
        {
            _taxBandRepository = uof.GetRepository<TaxBand>();
            _mapper = mapper;
        }

        public async Task<TaxBandsConsistencyResult> CheckConsistencyAsync()
        {

            var bands = await GetAllAsync();

            var validationMessages = ValidateTaxBands(bands);

            return new TaxBandsConsistencyResult
            {
                CheckResultMessages = validationMessages,
                IsConsistent = !validationMessages.Any()
            };
        }

        public async Task<IEnumerable<TaxBandModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TaxBandModel>>(await _taxBandRepository.GetAsync(sorter: x => x.LowerLimit));
        }

        private IEnumerable<string> ValidateTaxBands(IEnumerable<TaxBandModel> bands)
        {
            var resultMessages = new List<string>();
            var bandsArray = bands.ToArray();

            for (var i = 0; i < bandsArray.Length; i++)
            {
                if (i == 0)
                {
                    if (bandsArray[i].LowerLimit != 0)
                    {
                        resultMessages.Add("First tax bands doesn't contains zero-limit");
                    }
                }
                else if (i >= bandsArray.Length - 1)
                {
                    if (bandsArray[i].UpperLimit != null)
                    {
                        resultMessages.Add("Last tax band limited by upper limit, please add band without limitation");
                    }
                }
                else if (bandsArray[i].UpperLimit != bandsArray[i + 1].LowerLimit)
                {
                    resultMessages.Add(
                        $"Tax band '{bandsArray[i].Name}' (UpperLimit: {bandsArray[i].UpperLimit}) and '{bandsArray[i + 1].Name}'" +
                        $" (LowerLimit: {bandsArray[i + 1].LowerLimit}) doesn't cover each other");
                }

                if (bandsArray[i].UpperLimit <= bandsArray[i].LowerLimit)
                {
                    resultMessages.Add(
                        $"Tax band '{bandsArray[i].Name}': LowerLimit '{bandsArray[i].LowerLimit}'" +
                        $" should be less than UpperLimit '{bandsArray[i].UpperLimit}'");
                }
            }

            return resultMessages;
        }
    }
}
