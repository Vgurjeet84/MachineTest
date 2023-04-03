export interface Category {
  Id: string,
  Name: string,
  Total: number,
  subCategories: any
}

export interface subCategories {
  SubCategoryId: string,
  SubCategoryName: string,
  SubTotal: number
}



 export interface SubCategory {
   SubCategoryId: string,
   CategoryId: string,
   Name: string,
   Total: number
}
