using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StashContextSeed
    {
        public static async Task SeedAsync(StashContext context, ILoggerFactory loggerFactory)
        {   
            try
            {
                if(!context.Stashes.Any())
                {
                    var stashesData = File.ReadAllText("../Infrastructure/Data/SeedData/stashes.json");
                    var stashes = JsonSerializer.Deserialize<List<Stash>>(stashesData);
                    foreach (var item in stashes)
                    {
                        context.Stashes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.Items.Any())
                {
                    var itemsData = File.ReadAllText("../Infrastructure/Data/SeedData/items.json");
                    var items = JsonSerializer.Deserialize<List<Item>>(itemsData);
                    foreach (var item in items)
                    {
                        context.Items.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StashContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}