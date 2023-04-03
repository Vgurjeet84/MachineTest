using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NudeSolutionMachineTest.Class;
using NudeSolutionMachineTest.Interface;

namespace NudeSolutionMachineTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategory _category { get; set; }
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpGet]
        [Route("GetAllDetailCategory")]
        public IEnumerable<CategoryDetails> GetAllDetailCategory()
        {
            return _category.GetCategoryDetails();
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public IEnumerable<Models.Category> GetAllCategory()
        {
            return _category.GetAllCategory();
        }



        [HttpPost]
        [Route("AddCategory")]
        public async Task<ActionResult<Models.Category>> AddCategory([FromBody] Models.Category categoryReq)
        {
            categoryReq.Id = Guid.NewGuid();
            return await _category.AddCategory(categoryReq);
        }

        [HttpPost]
        [Route("AddSubCategory")]
        public async Task<ActionResult<Models.SubCategory>> AddSubCategory([FromBody] Models.SubCategory SubcategoryReq)
        {
            return await _category.AddSubCategory(SubcategoryReq);
        }

        [HttpDelete]
        [Route("DeleteSubCategory/{id:int}")]
        public async Task<bool> DeleteSubCategory([FromRoute] int id)
        {
            return await _category.Detele(id);
        }
    }
}
