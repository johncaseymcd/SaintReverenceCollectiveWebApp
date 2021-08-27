using System;
using System.Collections.Generic;
using System.Linq;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.CollectionModels;

namespace SaintReverenceMVC.Services
{
    public class CollectionService
    {
        // Create
        public bool CreateCollection(CollectionCreate model){
            var entity = new Collection{
                CollectionName = model.CollectionDescription,
                CollectionDescription = model.CollectionDescription,
                PublishDate = model.PublishDate,
                EndDate = model.EndDate
            };

            using (var ctx = new src_backendContext()){
                ctx.Collections.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get all Collections
        public IEnumerable<CollectionListItem> GetAllCollections(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Collections
                    .Select(cli => new CollectionListItem{
                        CollectionName = cli.CollectionName,
                        PublishDate = cli.PublishDate,
                        EndDate = cli.EndDate
                    });

                return query.ToList().OrderBy(o => o.PublishDate);
            }
        }

        // Get Collection by ID
        public CollectionDetail GetCollectionByID(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Collections.Find(id);

                return new CollectionDetail{
                    CollectionID = entity.CollectionID,
                    CollectionName = entity.CollectionName,
                    CollectionDescription = entity.CollectionDescription,
                    PublishDate = entity.PublishDate,
                    EndDate = entity.EndDate,
                    ProductsInCollection = entity.Products.Count
                };
            }
        }

        public IEnumerable<CollectionListItem> GetCollectionsEndingSoon(DateTime twoWeeks){
            using (var ctx = new src_backendContext()){
                var query = ctx.Collections
                    .Where(c => c.EndDate <= twoWeeks)
                    .Select(cli => new CollectionListItem{
                        CollectionName = cli.CollectionName,
                        PublishDate = cli.PublishDate, 
                        EndDate = cli.EndDate
                    });

                return query.ToList().OrderBy(o => o.EndDate);
            }
        }

        public bool UpdateCollection(CollectionEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Collections.Find(model.CollectionID);

                entity.CollectionName = model.CollectionName;
                entity.CollectionDescription = model.CollectionDescription;
                entity.PublishDate = model.PublishDate;
                entity.EndDate = model.EndDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCollection(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Collections.Find(id);
                ctx.Collections.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}