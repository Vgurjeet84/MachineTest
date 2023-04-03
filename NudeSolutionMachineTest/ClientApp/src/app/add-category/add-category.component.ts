import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/home/Category.model'
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  addCategory: Category = {
    Name: '',
    Id: '',
    Total: 0,
    subCategories:[]
  }


  constructor(private categoryservice: CategoryService, private router: Router) { }
  ngOnInit(): void {
  }
  



  AddCategory() {
    this.categoryservice.addCategory(this.addCategory).subscribe({
      next: (category) => {
        this.router.navigate(['']);
      }
    });
  }
}
