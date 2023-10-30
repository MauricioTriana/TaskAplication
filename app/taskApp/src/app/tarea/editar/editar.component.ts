import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Categoria } from 'src/app/shared/entities/categoria';
import { Persona } from 'src/app/shared/entities/persona';
import { Tarea } from 'src/app/shared/entities/tarea';
import { PersonaService } from 'src/app/shared/services/persona.service';
import { TareaService } from 'src/app/shared/services/tarea.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.scss']
})
export class EditarComponent implements OnInit, OnDestroy {

  private _taskId? : string | null;
  private _subs: Subscription[] = [];
  private _currentPersona: Persona = <Persona>{};
  private _currentCategoria: Categoria = <Categoria>{};
  
  public currentTarea : Tarea = <Tarea>{};
  public tareaForm: FormGroup= <FormGroup>{};

  constructor(
    private route: ActivatedRoute,
    private tareaService: TareaService,
    private personaService: PersonaService,
    private fb: FormBuilder,
    private router: Router 
  ) {}
  
  ngOnDestroy(): void {
    this._subs.forEach(x => x.unsubscribe());
  }

  ngOnInit(): void {
    this.getIdFromUrl();
    this.getTaskInformation();
  }

  private getIdFromUrl(){
    this.route.paramMap.subscribe(params => {
      if(params){
        this._taskId = params.get('id');
      } 
    });
  }

  private getCurrentCategoria(idCategoria: number){
    this._subs.push(
      this.tareaService.consultarCategoria(idCategoria).subscribe({
        next:(categs) => this._currentCategoria = categs,
        complete:() => this.setFormData() 
      })
    );
  }

  private getTaskInformation(){
    this._subs.push(
      this.tareaService.consultarTarea(+this._taskId!).subscribe({
        next:(tarea) => this.currentTarea = tarea,
        complete:() => this.getPersonInformation()
      })
    );
  }

  private getPersonInformation(){
    this._subs.push(
      this.personaService.consultarPersona(+this.currentTarea.idPersona!).subscribe({
        next:(persona) => this._currentPersona = persona,
        complete:() => this.buildEditForm()
      })
    );
  }

  private buildEditForm(){
    this.tareaForm = this.fb.group({
      asunto: ['', Validators.required], 
      detalle: ['', Validators.required],
      fechaLimite: ['', Validators.required],
      idPersona: ['', Validators.required],
      idCategoria: ['', Validators.required]
    });

    this.getCurrentCategoria(this.currentTarea.idCategoria!);
  }

  private setFormData(){
    this.getFormControl('asunto')?.setValue(this.currentTarea.asunto);
    this.getFormControl('detalle')?.setValue(this.currentTarea.detalle);
    this.getFormControl('fechaLimite')?.setValue(this.parseDate(this.currentTarea.fechaLimite!.toString()));
    this.getFormControl('idPersona')?.setValue(`${this._currentPersona.nombre} ${this._currentPersona.apellido}`);
    this.getFormControl('idCategoria')?.setValue(this._currentCategoria.nombre);
  }

  private parseDate(dateString: string): string {
    const date = new Date(dateString);
    const year = date.getFullYear();
    let month: any = date.getMonth() + 1;
    let day: any = date.getDate();

    // Adding zero padding if needed
    month = month < 10 ? '0' + month : month;
    day = day < 10 ? '0' + day : day;

    return `${year}-${month}-${day}`;
  }

  public getFormControl( campo: string ){
    return this.tareaForm.get(campo) as FormControl;
  }
  
  public onSubmit(){
    const tareaUpdate: Tarea = {
      id: this.currentTarea.id,
      asunto: this.getFormControl('asunto').value,
      detalle: this.getFormControl('detalle').value,
      fechaLimite: this.getFormControl('fechaLimite').value,
      idCategoria: this._currentCategoria.id,
      idPersona: this._currentPersona.id
    };
    this._subs.push(
      this.tareaService.actualizarTarea(tareaUpdate).subscribe(
        ()=> this.router.navigate(['/tarea'])
      )
    );
  }

  public deleteActivity(){
    this._subs.push(
      this.tareaService.eliminarTarea(+this._taskId!).subscribe(
        ()=> this.router.navigate(['/tarea'])
      )
    );
  }

}
