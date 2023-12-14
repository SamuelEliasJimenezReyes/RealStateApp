using AutoMapper;
using Microsoft.AspNetCore.Http;

using RealStateApp.Core.Application.Dtos.Account;
using RealStateApp.Core.Application.Helpers;
using RealStateApp.Core.Application.Interface.Repositories;
using RealStateApp.Core.Application.Interface.Services;
using RealStateApp.Core.Application.ViewModels.Agents;
using RealStateApp.Core.Application.ViewModels.Improvements;
using RealStateApp.Core.Application.ViewModels.ImprovementsProperties;
using RealStateApp.Core.Application.ViewModels.Properties;
using RealStateApp.Core.Domain.Entities;
using System.Collections.Generic;

namespace RealStateApp.Core.Application.Services
{
    public class PropertiesService : GenericService<SavePropertiesVM, PropertiesVM, Properties>, IPropertiesService
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IMapper _mapper;
        private readonly IPropertiesImprovementsService _propertiesImprovementsService;
        private readonly IAccountService _accountService;
        private readonly IImagesPropertiesService _imagesPropertiesService;
        private readonly AuthenticationResponse _userSession;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAgentImagesService _agentImagesService;
        private readonly IFavoritePropertiesRepository _favoritePropertiesRepository;
        private readonly IPropertiesImprovementsRepository _propertiesImprovementsRepository;

        public PropertiesService(IAgentImagesService agentImagesService,IPropertiesRepository propertiesRepository,
            IMapper mapper,
            IPropertiesImprovementsService propertiesImprovementsService, 
            IAccountService accountService,
            IImagesPropertiesService imagesPropertiesService,
            IPropertiesImprovementsRepository propertiesImprovementsRepository,
        IHttpContextAccessor httpContextAccessor,

            IFavoritePropertiesRepository favoritePropertiesRepository) : base(propertiesRepository, mapper)
        {
            _propertiesRepository = propertiesRepository;
            _mapper = mapper;
            _propertiesImprovementsService = propertiesImprovementsService;
            _accountService = accountService;
            _imagesPropertiesService = imagesPropertiesService;
            _httpContextAccessor = httpContextAccessor;
            _userSession = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _agentImagesService = agentImagesService;
            _favoritePropertiesRepository = favoritePropertiesRepository;
            _propertiesImprovementsRepository = propertiesImprovementsRepository;
        }



        public override async Task<SavePropertiesVM> Add(SavePropertiesVM vm)
        {
            var propertiesList = await base.GetAllViewModel();
            vm.AgentId = _userSession.Id;

            vm.Code = GenerateUniquecode.GenerateUniqueCode(propertiesList);

            var svm = await base.Add(vm);

            foreach(var improvements in vm.PropertiesImprovementsId)
            {
                var saveImprovementsProperties = new SavePropertiesImprovementsVM
                {
                   PropertiesId = svm.Id,
                   ImprovementId = improvements
                };

                await _propertiesImprovementsService.Add(saveImprovementsProperties);
            }
            
            return svm;
        }

        public async Task<List<PropertiesVM>> GetAllPropertiesVM(PropertiesFilterVM filter)
        {
            var list = await _propertiesRepository.GetAllWithIncludeAsync(new List<string> { "SaleType", "PropertiesTypes" });
            var vmList = new List<PropertiesVM>();


            if (filter.Min.HasValue)
            {
                list = list.Where(x => x.Price >= filter.Min.Value).ToList();
            }

             if (filter.Max.HasValue)
            {
                list = list.Where(x => x.Price <= filter.Max.Value).ToList();
            }

            if (filter.BathroomQuantity > 0)
            {
                list = list.Where(x => x.BathroomQuantity >= filter.BathroomQuantity.Value).ToList();
            }

            if (filter.BedroomQuantity > 0)
            {
                list = list.Where(x => x.RoomQuantity >= filter.BedroomQuantity.Value).ToList();
            }

            if (filter.PropertiesTypeId > 0)
            {
                list = list.Where(x => x.PropertiesTypeId == filter.PropertiesTypeId).ToList();
            }

            if (!string.IsNullOrEmpty(filter.PropertyCode))
            {
                list = list.Where(x => x.Code.Contains(filter.PropertyCode)).ToList();
            }

            if (filter.AgentId != null)
            {
                list = list.Where(x => x.AgentId == filter.AgentId).ToList();
            }

            foreach (var properties in list)
            {
                var agent = await _accountService.GetUserById(properties.AgentId);
                agent.ImagePath = await _agentImagesService.GetImagesByAgentId(properties.AgentId);

                var dtoProperty = new PropertiesVM
                {
                    Description = properties.Description,
                    BathroomQuantity = properties.BathroomQuantity,
                    RoomQuantity = properties.RoomQuantity,
                    LandSizeMeter = properties.LandSizeMeter,
                    Price = properties.Price,
                    Id = properties.Id,
                    Code = properties.Code,
                    PropertiesType = properties.PropertiesTypes.Name,
                    SaleType = properties.SaleType.Name,
                    PropertiesImprovements = await _propertiesImprovementsService.GetImprovementsByPropertyId(properties.Id),
                    Agent = _mapper.Map<AgentVM>(agent),
                    ImagesProperties = await _imagesPropertiesService.GetAllImagesByPropertyId(properties.Id)
                 };

                vmList.Add(dtoProperty);
            }




            return vmList;
        }

        public async Task<PropertiesVM> GetPropertyByCode(string code)
        {
            var list = await _propertiesRepository.GetAllWithIncludeAsync(new List<string> { "SaleType", "PropertiesTypes" });

            var properties = list.FirstOrDefault(x => x.Code == code);

            var agent = await _accountService.GetUserById(properties.AgentId);
            agent.ImagePath = await _agentImagesService.GetImagesByAgentId(properties.AgentId);

            var dtoProperty = new PropertiesVM
            {
                Description = properties.Description,
                BathroomQuantity = properties.BathroomQuantity,
                RoomQuantity = properties.RoomQuantity,
                LandSizeMeter = properties.LandSizeMeter,
                Price = properties.Price,
                Id = properties.Id,
                Code = properties.Code,
                PropertiesType = properties.PropertiesTypes.Name,
                SaleType = properties.SaleType.Name,
                PropertiesImprovements = await _propertiesImprovementsService.GetImprovementsByPropertyId(properties.Id),
                Agent = _mapper.Map<AgentVM>(agent),
                ImagesProperties = await _imagesPropertiesService.GetAllImagesByPropertyId(properties.Id),
            };

            return dtoProperty;
        }

        public override async Task Update(SavePropertiesVM vm, int id)
        {
            var listImprovements = await _propertiesImprovementsRepository
                                           .GetAllAsync();

            var existingImprovements = listImprovements.Where(x => x.PropertiesId == id)
                                           .Select(x => x.ImprovementId)
                                           .ToList();

              var improvementsToRemove = existingImprovements.Except(vm.PropertiesImprovementsId).ToList();

             foreach (var improvementId in improvementsToRemove)
            {
                await _propertiesImprovementsRepository.DeletePropertiesImprovements(vm.Id, improvementId);
            }

             var newImprovementsToAdd = vm.PropertiesImprovementsId.Except(existingImprovements).ToList();

            foreach (var newImprovementId in newImprovementsToAdd)
            {
                var saveImprovementsProperties = new SavePropertiesImprovementsVM
                {
                    PropertiesId = vm.Id,
                    ImprovementId = newImprovementId
                };

                await _propertiesImprovementsService.Add(saveImprovementsProperties);
            }

            await base.Update(vm, id);
        }

        public async Task AddFavoriteProperties(int propertyId, string clientId) 
        {
            FavoriteProperties favoriteProperties = new()
            {
                PropertiesId = propertyId,
                ClientId = clientId
            };

            await _favoritePropertiesRepository.AddAsync(favoriteProperties);
        }

        public async Task RemoveFavoriteProperty(string clientId, int propertyId)
        {
            await _favoritePropertiesRepository.RemoveFavoriteProperty(clientId, propertyId);
        }

        public async Task<List<PropertiesVM>> GetPropertiesForClient()
        {
            var list = await GetAllPropertiesVM(new PropertiesFilterVM());

            var favoriteIds = await _favoritePropertiesRepository.GetFavoritePropertiesId(_userSession.Id);

            foreach(var favoriteId in favoriteIds)
            {
                foreach (var property in list)
                {
                    if(property.Id == favoriteId)
                    {
                        property.IsFavorite = true;
                    }
                }
            }

            return list;
        }

        public async Task<List<PropertiesVM>> GetFavoritePropertiesForClient()
        {
            var list = await GetAllPropertiesVM(new PropertiesFilterVM());

            var favoriteIds = await _favoritePropertiesRepository.GetFavoritePropertiesId(_userSession.Id);
            var favoriteList = new List<PropertiesVM>();

            foreach (var favoriteId in favoriteIds)
            {
                foreach (var property in list)
                {
                    if (property.Id == favoriteId)
                    {
                        property.IsFavorite = true;
                        favoriteList.Add(property);
                    }
                }
            }

            return favoriteList;
        }

        
    }
}

