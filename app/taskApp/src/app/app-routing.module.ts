import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'persona',
    loadChildren: () => import ('./persona/persona.module').then(m => m.PersonaModule)
  },
  {
    path: 'tarea',
    loadChildren: () => import ('./tarea/tarea.module').then(m => m.TareaModule)
  },
  {
    path: 'shared',
    loadChildren: () => import ('./shared-module/shared-module.module').then(m => m.SharedModuleModule)
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
