import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConsultarComponent } from './consultar/consultar.component';
import { RegistrarComponent } from './registrar/registrar.component';
import { EditarComponent } from './editar/editar.component';
import { TareaRoutingModule } from './tarea-routing.module';
import { SharedModuleModule } from '../shared-module/shared-module.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ConsultarComponent,
    RegistrarComponent,
    EditarComponent
  ],
  imports: [
    CommonModule,
    TareaRoutingModule,
    SharedModuleModule,
    ReactiveFormsModule 
  ]
})
export class TareaModule { }
