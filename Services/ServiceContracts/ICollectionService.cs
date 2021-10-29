using System;
using SaintReverenceMVC.Models.CollectionModels;
using System.Collections.Generic;

namespace SaintReverenceMVC.Services.ServiceContracts{
    public interface ICollectionService{
        bool CreateCollection(CollectionCreate model);
        IEnumerable<CollectionListItem> GetAllCollections();
        CollectionDetail GetCollectionByID(int id);
        IEnumerable<CollectionListItem> GetCollectionsEndingSoon();
        bool UpdateCollection(CollectionEdit model);
        bool DeleteCollection(int id);
    }
}