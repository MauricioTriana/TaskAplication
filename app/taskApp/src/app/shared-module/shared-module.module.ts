import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { sharedRoutingModule } from './shared-routing.module';
import { ListItemComponent } from './list/list-item/list-item.component';
import { ListObjectsComponent } from './list/list-objects/list-objects.component';

@NgModule({
  declarations: [
    ListItemComponent,
    ListObjectsComponent
  ],
  imports: [
    CommonModule,
    sharedRoutingModule
  ],
  exports: [
    ListItemComponent,
    ListObjectsComponent
  ]
})
export class SharedModuleModule { }
