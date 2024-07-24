import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { response } from 'express';
import { get } from 'http';
import { Products } from './Models/Products';
import { Pagination } from './Models/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'client';
  products: Products[] = [];

  constructor(private http: HttpClient) {
  }
  ngOnInit(): void {
    this.http.get<Pagination<Products[]>>('https://localhost:5001/Api/product?sort=priceDesc').subscribe({
      next: response   => this.products = response.data,
      error:error => console.log(error),
      complete: () =>{
        console.log("req completed");
      }   
    })
  }

}
