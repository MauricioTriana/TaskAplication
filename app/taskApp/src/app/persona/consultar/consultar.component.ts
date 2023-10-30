import { Component, OnDestroy, OnInit } from '@angular/core';
import { PersonaService } from '../../shared/services/persona.service';
import { Persona } from '../../shared/entities/persona';
import { Subscription } from 'rxjs';
import { cardObject } from 'src/app/shared/entities/card-object';
@Component({
  selector: 'app-consultar',
  templateUrl: './consultar.component.html',
  styleUrls: ['./consultar.component.scss']
})
export class ConsultarComponent implements OnInit, OnDestroy {

  constructor(private personaService: PersonaService) { }

  private _subs: Subscription[] = [];

  public persona: Persona[] = [];
  public personaObjectList: cardObject[] = [];

  ngOnInit(): void {
    this.getPersonasData();
  }

  ngOnDestroy(): void {
    this._subs.forEach(sub => sub.unsubscribe());
  }

  private getPersonasData(){
    this._subs.push(
      this.personaService.consultarPersonas().subscribe({
        next:(personas) => this.persona = personas,
        complete:() =>this.convertPersonastoObjectList() 
      })
    );
  }

  private convertPersonastoObjectList(){
    this.persona.forEach( x => {
      this.personaObjectList.push({
        title: `${x.nombre} ${x.apellido}`,
        description: ` identificación: ${x.cedula}, tel: ${x.telefono}`,
        canEdit: false,
        imgDirection: this.generatePersonAvatar(x.nombre)
      })
    });
  }

  private generatePersonAvatar(name: string): string{
    return `https://robohash.org/${name}.png`;
  }

}
