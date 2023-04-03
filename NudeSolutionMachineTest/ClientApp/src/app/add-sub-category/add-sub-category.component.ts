import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category, SubCategory } from 'src/app/home/Category.model'
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-add-sub-category',
  templateUrl: './add-sub-category.component.html',
  styleUrls: ['./add-sub-category.component.css']
})
export class AddSubCategoryComponent implements OnInit {

  addSubCategory: SubCategory = {
    Name: '',
    SubCategoryId: '',
    CategoryId:'',
    Total: 0
  }


categories: Category[] = [];

  constructor(private categoryservice: CategoryService, private router: Router) { }

  ngOnInit(): void {
    this.categoryservice.getAllCategory()
      .subscribe({
        next: (categories) => {
          this.categories = categories;
        },
        error: (response) => {
          console.log("Error " + response);
        }
      })
  }

  AddSubCategory() {
    this.categoryservice.addSubCategory(this.addSubCategory).subscribe({
      next: (category) => {
        this.router.navigate(['']);
      }
    });
  }


}
