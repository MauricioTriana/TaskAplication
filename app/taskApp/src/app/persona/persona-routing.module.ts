import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ConsultarComponent} from './consultar/consultar.component'
const routes: Routes = [
  {
    path:'',
    children:[
      {
        path:'consultar',component: ConsultarComponent
      },
      {
        path:'**', redirectTo:'consultar'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonaRoutingModule { }
