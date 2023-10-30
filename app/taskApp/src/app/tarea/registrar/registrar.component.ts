import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Categoria } from 'src/app/shared/entities/categoria';
import { Persona } from 'src/app/shared/entities/persona';
import { Tarea } from 'src/app/shared/entities/tarea';
import { PersonaService } from 'src/app/shared/services/persona.service';
import { TareaService } from 'src/app/shared/services/tarea.service';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.scss']
})
export class RegistrarComponent implements OnInit {

  private _subs: Subscription[] = [];
  private _currentPersona: Persona = <Persona>{};

  public categorias: Categoria [] = [];
  public currentTarea : Tarea = <Tarea>{};
  public tareaForm: FormGroup= <FormGroup>{};

  constructor(
    private tareaService: TareaService,
    private personaService: PersonaService,
    private fb: FormBuilder,
    private router: Router 
  ) {}
  
  ngOnDestroy(): void {
    this._subs.forEach(x => x.unsubscribe());
  }

  ngOnInit(): void {
    this.getCategorias();
    this.getPersonInformation();
  }

  private getCategorias(){
    this._subs.push(
      this.tareaService.consultarCategorias().subscribe((categs) => this.categorias = categs)
    );
  }

  private getPersonInformation(){
    this._currentPersona = this.personaService.geturrentUser();
    this.buildForm();
  }

  private buildForm(){
    this.tareaForm = this.fb.group({
      asunto: ['', Validators.required], 
      detalle: ['', Validators.required],
      fechaLimite: ['', Validators.required],
      idPersona: ['', Validators.required],
      idCategoria: ['', Validators.required]
    });

    this.setFormData();
  }

  private setFormData(){
    this.getFormControl('idPersona')?.setValue(`${this._currentPersona.nombre} ${this._currentPersona.apellido}`);
  }

  public getFormControl( campo: string ){
    return this.tareaForm.get(campo) as FormControl;
  }
  
  public onSubmit(){
    const tareaUpdate: Tarea = {
      asunto: this.getFormControl('asunto').value,
      detalle: this.getFormControl('detalle').value,
      fechaLimite: this.getFormControl('fechaLimite').value,
      idCategoria: this.getFormControl('idCategoria').value,
      idPersona: this._currentPersona.id
    };
    this._subs.push(
      this.tareaService.insertarTarea(tareaUpdate).subscribe(
        ()=> this.router.navigate(['/tarea'])
      )
    );
  }
}
