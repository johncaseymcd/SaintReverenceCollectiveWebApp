using System;
using Xunit;
using SaintReverenceMVC.Data;
using SaintReverenceMVC.Models;
using SaintReverenceMVC.Services;

namespace SaintReverenceMVC.Tests
{
    public class CollectionCreateTest_Should
    {
        [Fact]
        public void CollectionCreate_CollectionEntity_ShouldIncreaseDBRowBy1(Collection testModel)
        {
            src_backendContext context = new();
            int initialCount = 0;
            foreach(var row in context.Collections){
                initialCount++;
            }
            context.Collections.Add(testModel);

            int finalCount = 0;
            foreach(var row in context.Collections){
                finalCount++;
            }

            Assert.True(finalCount > initialCount);
            Assert.False(finalCount == initialCount);
        }
    }
}
