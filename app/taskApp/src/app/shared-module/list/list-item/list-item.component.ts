import { Component, Input, OnInit } from '@angular/core';
import { cardObject } from 'src/app/shared/entities/card-object';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.scss']
})
export class ListItemComponent implements OnInit {

  public itemObject? : cardObject;

  @Input()  
  public set objectItem(v : cardObject) {
    this.itemObject = v;
  }
  

  constructor() { }

  ngOnInit(): void {
  }

}
