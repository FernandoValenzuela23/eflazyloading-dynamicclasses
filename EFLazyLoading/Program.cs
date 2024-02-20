/*

SQL SERVER ON DOCKER
https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash

 */


using EFLazyLoading.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

string bdConnectionString = ConfigurationManager.ConnectionStrings["BeerDatabase"].ConnectionString;

var optionsBuilder = new DbContextOptionsBuilder<BeerContext>()        
        .UseLazyLoadingProxies(true)
        .LogTo(s => Console.WriteLine(s))
        .UseSqlServer(bdConnectionString);

using(var db = new BeerContext(optionsBuilder.Options))
{
    #region Data Creation
    var exists = await db.Brands.FirstOrDefaultAsync(p => p.Name == "Heineken INC.");
    int brandId = 0;
    if(exists == null)
    {
        Brand newBrand = new Brand()
        {
            Name = "Heineken INC."
        };

        await db.AddAsync<Brand>(newBrand);
        brandId = await db.SaveChangesAsync();

        List<Beer> beersBrand = new List<Beer>();
        beersBrand.Add(new Beer
        {
            Name = "Heineken",
            BrandId = brandId,
            Alcohol = 12.0M
        });
        beersBrand.Add(new Beer
        {
            Name = "Heineken The best",
            BrandId = brandId,
            Alcohol = 18.0M
        });

        foreach (var item in beersBrand)
        {
            var bbeer = await db.Beers.FirstOrDefaultAsync(p => p.Name == item.Name);
            if (bbeer == null)
            {
                await db.AddAsync<Beer>(item);
                await db.SaveChangesAsync();
            }
        }
    }
    else
    {
        brandId = exists.Id;
    }

    #endregion

    #region Lazy loading

    var brands = await db.Brands.ToListAsync();

    Console.WriteLine(brands[0].Beers.Count);

    #endregion


}




