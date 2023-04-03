using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NudeSolutionMachineTest.Data;
using NudeSolutionMachineTest.Interface;
using NudeSolutionMachineTest.Models;

namespace NudeSolutionMachineTest.Class
{

    public class Category : ICategory
    {
        private readonly MachineTestDbContext _dbContext;
        public Category(MachineTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryDetails> GetCategoryDetails()
        {
            List<CategoryDetails> categoryDetails = new List<CategoryDetails>();
            try
            {
                var category = _dbContext.Categories.ToList();

                foreach (var item in category)
                {
                    categoryDetails.Add(new CategoryDetails
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Total = SumOfSubCategory(item.Id),
                        subCategories = GetSubCategory(item.Id)
                    });
                }

                return categoryDetails;
            }
            catch (Exception ex)
            {
                return categoryDetails;
            }

        }


        public List<Models.Category> GetAllCategory()
        {
            return _dbContext.Categories.ToList();
        }


        public async Task<ActionResult<Models.Category>> AddCategory(Models.Category categoryReq)
        {
            await _dbContext.Categories.AddAsync(categoryReq);
            await _dbContext.SaveChangesAsync();
            return categoryReq;
        }

        public async Task<ActionResult<Models.SubCategory>> AddSubCategory(Models.SubCategory SubcategoryReq)
        {
            await _dbContext.SubCategories.AddAsync(SubcategoryReq);
            await _dbContext.SaveChangesAsync();
            return SubcategoryReq;
        }


        public async Task<bool> Detele(int id)
        {
            var result = await _dbContext.SubCategories.FindAsync(id);
            _dbContext.SubCategories.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public int SumOfSubCategory(Guid Category)
        {
            return _dbContext.SubCategories.
                Where(i => i.CategoryId == Category).
                Select(t => t.Total).Sum();
        }

        public List<SubCategory> GetSubCategory(Guid Category)
        {
            return (from s in _dbContext.SubCategories.Where(i => i.CategoryId == Category)
                    select new SubCategory
                    {
                        SubCategoryId = s.SubCategoryId,
                        SubCategoryName = s.Name,
                        SubTotal = Convert.ToInt32(s.Total)
                    }).ToList();
        }
    }





    public class CategoryDetails
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Total { get; set; }
        public List<SubCategory> subCategories { get; set; }
    }

    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int SubTotal { get; set; }
    }

}
