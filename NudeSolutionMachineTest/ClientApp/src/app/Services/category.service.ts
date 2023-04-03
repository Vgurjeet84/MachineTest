import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category, subCategories, SubCategory } from '../home/Category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {



  public url: string = "";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl
  }

  getAllCategory(): Observable<Category[]> {
    return this.http.get<Category[]>(this.url + 'category/GetAllDetailCategory')
  }

  addCategory(categoryReq: Category): Observable<Category> {
    categoryReq.Id = '00000000-0000-0000-0000-000000000000'
    return this.http.post<Category>(this.url + 'category/AddCategory', categoryReq)
  }

  addSubCategory(SubCategoryReq: SubCategory): Observable<SubCategory> {    
    SubCategoryReq.SubCategoryId = '0';
    return this.http.post<SubCategory>(this.url + 'category/AddSubCategory', SubCategoryReq)
  }

  deleteSubCategory(id: string): Observable<boolean> {
    return this.http.delete<boolean>(this.url + 'category/DeleteSubCategory/' + id)
  }


}
