using System;
using System.Collections.Generic;
using System.Linq;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models.CollectionModels;
using SaintReverenceMVC.Services.ServiceContracts;
using System.Threading.Tasks;

namespace SaintReverenceMVC.Services
{
    public class CollectionService : ICollectionService
    {
        public Task<bool> CreateCollectionAsync(CollectionCreate model){
            var entity = new Collection{
                CollectionName = model.CollectionDescription,
                CollectionDescription = model.CollectionDescription,
                PublishDate = model.PublishDate,
                EndDate = model.EndDate
            };

            using (var ctx = new src_backendContext()){
                ctx.Collections.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public Task<IEnumerable<CollectionListItem>> GetAllCollectionsAsync(){
            using (var ctx = new src_backendContext()){
                var query = ctx.Collections
                    .Select(cli => new CollectionListItem{
                        CollectionID = cli.CollectionID,
                        CollectionName = cli.CollectionName,
                        PublishDate = cli.PublishDate,
                        EndDate = cli.EndDate
                    });

                return await query.ToListAsync().OrderBy(o => o.PublishDate);
            }
        }

        public Task<CollectionDetail> GetCollectionByIDAsync(int id){
            using (var ctx = new src_backendContext()){
                var entity = await ctx.Collections.FindAsync(id);

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

        // Get Collections with end dates within two weeks from current date
        public Task<IEnumerable<CollectionListItem>> GetCollectionsEndingSoonAsync(){
            using (var ctx = new src_backendContext()){
                DateTime twoWeeks = DateTime.Now.AddDays(14);
                var query = ctx.Collections
                    .Where(c => c.EndDate <= twoWeeks)
                    .Select(cli => new CollectionListItem{
                        CollectionID = cli.CollectionID,
                        CollectionName = cli.CollectionName,
                        PublishDate = cli.PublishDate, 
                        EndDate = cli.EndDate
                    });

                return await query.ToListAsync().OrderBy(o => o.EndDate);
            }
        }

        public Task<bool> UpdateCollectionAsync(CollectionEdit model){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Collections.Find(model.CollectionID);
                
                entity.CollectionName = model.CollectionName;
                entity.CollectionDescription = model.CollectionDescription;
                entity.PublishDate = model.PublishDate;
                entity.EndDate = model.EndDate;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public Task<bool> DeleteCollectionAsync(int id){
            using (var ctx = new src_backendContext()){
                var entity = ctx.Collections.Find(id);
                ctx.Collections.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}