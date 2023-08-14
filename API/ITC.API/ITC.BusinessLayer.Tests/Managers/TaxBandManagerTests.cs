using AutoMapper;
using FakeItEasy;
using ITC.BusinessLayer.Managers;
using ITC.BusinessLayer.Managers.Interfaces;
using ITC.BusinessLayer.MappingProfiles;
using ITC.DataAccess.Entities;
using ITC.DataAccess.Interfaces;
using ITC.DataAccess.Interfaces.Repositories;
using System.Linq.Expressions;
using Xunit;

namespace ITC.BusinessLayer.Tests.Managers
{
    public class TaxBandManagerTests
    {
        private readonly ITaxBandManager _sut;

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TaxBand> _taxBandRepository;

        public TaxBandManagerTests()
        {
            _uow = A.Fake<IUnitOfWork>();
            _taxBandRepository = A.Fake<IGenericRepository<TaxBand>>();
            A.CallTo(() => _uow.GetRepository<TaxBand>()).Returns(_taxBandRepository);

            _mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<TaxBandProfile>();
            }));

            _sut = new TaxBandManager(_uow, _mapper);
        }

        [Fact]
        public async Task CheckConsistencyAsync_AllBandsValid_ReturnsResultAsValid()
        {
            // Arrange
            var taxBands = new List<TaxBand> {
                 new TaxBand {
                    Name = "Band 1",
                    UpperLimit = 5000,
                    LowerLimit = 0,
                    Rate = 0
                 },
                 new TaxBand {
                    Name = "Band 2",
                    UpperLimit = 20000,
                    LowerLimit = 5000,
                    Rate = 20
                 },
                 new TaxBand {
                    Name = "Band 3",
                    UpperLimit = default(int?),
                    LowerLimit = 20000,
                    Rate = 40
                 }
                };
            A.CallTo(() => _taxBandRepository.GetAsync(null, A<Expression<Func<TaxBand, object>>>._, false, null, null)).Returns(taxBands);

            // Act
            var result = await _sut.CheckConsistencyAsync();

            // Assert
            Assert.True(result.IsConsistent);
            Assert.Empty(result.CheckResultMessages);
        }

        [Fact]
        public async Task CheckConsistencyAsync_AbsentZeroBand_ReturnsNotValidResultWithMessageAboutZeroBand()
        {
            // Arrange
            var taxBands = new List<TaxBand> {
                 new TaxBand {
                    Name = "Band 1",
                    UpperLimit = 5000,
                    LowerLimit = 1,
                    Rate = 0
                 },
                 new TaxBand {
                    Name = "Band 2",
                    UpperLimit = 20000,
                    LowerLimit = 5000,
                    Rate = 20
                 },
                 new TaxBand {
                    Name = "Band 3",
                    UpperLimit = default(int?),
                    LowerLimit = 20000,
                    Rate = 40
                 }
                };
            A.CallTo(() => _taxBandRepository.GetAsync(null, A<Expression<Func<TaxBand, object>>>._, false, null, null)).Returns(taxBands);

            // Act
            var result = await _sut.CheckConsistencyAsync();

            // Assert
            Assert.False(result.IsConsistent);
            Assert.NotEmpty(result.CheckResultMessages);
            Assert.Contains("First tax bands doesn't contains zero-limit", result.CheckResultMessages);
        }

        [Fact]
        public async Task CheckConsistencyAsync_LimitedLastBand_ReturnsNotValidResultWithMessageAboutLastLimitedBand()
        {
            // Arrange
            var taxBands = new List<TaxBand> {
                 new TaxBand {
                    Name = "Band 1",
                    UpperLimit = 5000,
                    LowerLimit = 0,
                    Rate = 0
                 },
                 new TaxBand {
                    Name = "Band 2",
                    UpperLimit = 20000,
                    LowerLimit = 5000,
                    Rate = 20
                 },
                 new TaxBand {
                    Name = "Band 3",
                    UpperLimit = 20001,
                    LowerLimit = 20000,
                    Rate = 40
                 }
                };
            A.CallTo(() => _taxBandRepository.GetAsync(null, A<Expression<Func<TaxBand, object>>>._, false, null, null)).Returns(taxBands);

            // Act
            var result = await _sut.CheckConsistencyAsync();

            // Assert
            Assert.False(result.IsConsistent);
            Assert.NotEmpty(result.CheckResultMessages);
            Assert.Contains("Last tax band limited by upper limit, please add band without limitation", result.CheckResultMessages);
        }

        [Fact]
        public async Task CheckConsistencyAsync_UpperLimitLessThanLowerButGreaterBands_ReturnsNotValidResultWithMessagesAboutWrongUpperAndLowerLimits()
        {
            // Arrange
            var taxBands = new List<TaxBand> {
                 new TaxBand {
                    Name = "Band 1",
                    UpperLimit = 5000,
                    LowerLimit = 0,
                    Rate = 0
                 },
                 new TaxBand {
                    Name = "Band 2",
                    UpperLimit = 5000,
                    LowerLimit = 5001,
                    Rate = 20
                 },
                 new TaxBand {
                    Name = "Band 3",
                    UpperLimit = 20000,
                    LowerLimit = 20001,
                    Rate = 40
                 }
                };
            A.CallTo(() => _taxBandRepository.GetAsync(null, A<Expression<Func<TaxBand, object>>>._, false, null, null)).Returns(taxBands);

            // Act
            var result = await _sut.CheckConsistencyAsync();

            // Assert
            Assert.False(result.IsConsistent);
            Assert.NotEmpty(result.CheckResultMessages);
            Assert.Collection(
                result.CheckResultMessages,
                x => x.Contains("doesn't cover each other"),
                x => x.Contains("should be less than UpperLimit"),
                x => x.Contains("doesn't cover each other"),
                x => x.Contains("should be less than UpperLimit"));
        }
    }
}
