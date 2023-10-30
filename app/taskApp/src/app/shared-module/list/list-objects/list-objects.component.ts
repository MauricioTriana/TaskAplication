import { Component, Input, OnInit } from '@angular/core';
import { cardObject } from 'src/app/shared/entities/card-object';

@Component({
  selector: 'app-list-objects',
  templateUrl: './list-objects.component.html',
  styleUrls: ['./list-objects.component.scss']
})
export class ListObjectsComponent implements OnInit {

  public itemObjects : cardObject[] = [];

  @Input()  
  public set objectItems(v : cardObject[]) {
    if (v.length >0){
      console.log (v);
      this.itemObjects = v;
    }
      
  }

  constructor() { }

  ngOnInit(): void {
  }

}
