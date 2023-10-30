import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ConsultarComponent} from './consultar/consultar.component';
import {RegistrarComponent} from './registrar/registrar.component';
import {EditarComponent} from './editar/editar.component';
const routes: Routes = [
  {
    path: '',
    children:[
      {path: 'consultar', component:ConsultarComponent},
      {path: 'registrar', component:RegistrarComponent},
      {path: 'editar/:id', component:EditarComponent},
      {path: '**', redirectTo: 'consultar'}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TareaRoutingModule { }
