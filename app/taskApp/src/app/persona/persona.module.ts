import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonaRoutingModule } from './persona-routing.module';
import { ConsultarComponent } from './consultar/consultar.component';
import { SharedModuleModule } from '../shared-module/shared-module.module';

@NgModule({
  declarations: [
    ConsultarComponent
  ],
  imports: [
    CommonModule,
    PersonaRoutingModule,
    SharedModuleModule
  ]
})
export class PersonaModule { }
