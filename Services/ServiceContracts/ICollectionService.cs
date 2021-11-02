using System;
using SaintReverenceMVC.Models.CollectionModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface ICollectionService{
        Task<bool> CreateCollectionAsync(CollectionCreate model);
        Task<IEnumerable<CollectionListItem>> GetAllCollectionsAsync();
        CollectionDetail GetCollectionByID(int id);
        Task<IEnumerable<CollectionListItem>> GetCollectionsEndingSoonAsync();
        Task<bool> UpdateCollectionAsync(CollectionEdit model);
        Task<bool> DeleteCollectionAsync(int id);
    }
}