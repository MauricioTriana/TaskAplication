import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { cardObject } from 'src/app/shared/entities/card-object';
import { Categoria } from 'src/app/shared/entities/categoria';
import { Tarea } from 'src/app/shared/entities/tarea';
import { TareaService } from 'src/app/shared/services/tarea.service';

@Component({
  selector: 'app-consultar',
  templateUrl: './consultar.component.html',
  styleUrls: ['./consultar.component.scss']
})
export class ConsultarComponent implements OnInit {

  constructor(
    private tareaService: TareaService,
    private router: Router
  ) { }
  private _subs: Subscription[] = [];
  private _categorias: Categoria [] = [];
  public tareas: Tarea[] = [];

  public tareaObjectList: cardObject[] = [];

  ngOnInit(): void {
    this.getTareasData();
  }

  ngOnDestroy(): void {
    this._subs.forEach(sub => sub.unsubscribe());
  }

  private getTareasData(){
    this._subs.push(
      this.tareaService.consultarTareas().subscribe({
        next:(tasks) => this.tareas = tasks,
        complete:() =>this.consultarCategorias() 
      })
    );
  }

  private consultarCategorias(){
    this._subs.push(
      this.tareaService.consultarCategorias().subscribe({
        next:(categorias) => this._categorias = categorias,
        complete:() => this.convertTareastoObjectList()        
      })
    );
  }

  private convertTareastoObjectList() {
    this.tareas.forEach( x => {

      const currentCategory = this._categorias.filter(y => y.id === x.idCategoria);

      this.tareaObjectList.push({
        objectId: x.id,
        title: `${x.asunto}`,
        description: `fecha limite: ${x.fechaLimite}, categoria: ${currentCategory[0].nombre}, detalle: ${x.detalle}`,
        canEdit: true,
        redirectionText: 'Gestionar tarea',
        editRedirection:`/tarea/editar/${x.id}`
      })
    });
  }

  public registrarActividad(){
    this.router.navigate(['/tarea/registrar']);
  }

}
