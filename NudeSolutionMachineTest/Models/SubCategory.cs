namespace NudeSolutionMachineTest.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
    }
}
