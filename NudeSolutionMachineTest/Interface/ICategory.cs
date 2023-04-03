using Microsoft.AspNetCore.Mvc;
using NudeSolutionMachineTest.Class;

namespace NudeSolutionMachineTest.Interface
{
    public interface ICategory
    {
        List<CategoryDetails> GetCategoryDetails();
        List<Models.Category> GetAllCategory();
        Task<ActionResult<Models.Category>> AddCategory(Models.Category categoryReq);
        Task<ActionResult<Models.SubCategory>> AddSubCategory(Models.SubCategory SubcategoryReq);
        Task<bool> Detele(int id);
    }
}
