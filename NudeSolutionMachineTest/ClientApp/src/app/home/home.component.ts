import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/home/Category.model'
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  categories: Category[] = [];
  MainTotal: number = 0;

  constructor(private categoriesService: CategoryService, private router: Router) { };

  ngOnInit(): void {
    this.categoriesService.getAllCategory()
      .subscribe({
        next: (categories) => {

          this.MainTotal = categories.map(a => a.Total).reduce(function (a, b) {
            return a + b;
          });

          this.categories = categories;
        },
        error: (response) => {
          console.log("Error "+response);
        }
      })
  }

  DeleteSubCategory(id: string) {
    this.categoriesService.deleteSubCategory(id).subscribe({
      next: (response) => {
        this.ngOnInit();
      }
    });
  }
}
