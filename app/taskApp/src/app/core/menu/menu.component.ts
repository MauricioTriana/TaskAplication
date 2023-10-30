import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { Router } from '@angular/router';

import { LocalStorageService } from '../../shared/services/local-storage.service';
import { PersonaService } from '../../shared/services/persona.service';
import { Persona } from 'src/app/shared/entities/persona';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit, OnDestroy {

  constructor(
    private localStorage: LocalStorageService,
    private personaService: PersonaService,
    private router: Router
    ) { }

  private CurrentUserCC = "CurrentUserCC";
  private subscription: Subscription = new Subscription();
  public badLogginAttemp = false;
  public isUserloged = false;


  public fgLogin:FormGroup = new FormGroup({
    identificacion: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }


  public validateIsUserloged(){
    var lSuser = this.localStorage.getFromStorage(this.CurrentUserCC);
    this.isUserloged =  !! lSuser;
  }

  public getControlLogin(controlName : string){
    return (this.fgLogin.get(controlName)) as FormControl;
  }

  public LoginSesion(){
    this.badLogginAttemp = false;
    const user = this.getControlLogin('identificacion').value;
    const pass = this.getControlLogin('password').value;
    this.subscription = this.personaService.loginPersona( user, pass ).subscribe( arg =>
      {
        if (arg === true){
          this.setPersonInformation(user);
          this.localStorage.setToStorage(this.CurrentUserCC, user);
          this.isUserloged = true;
        }else{
          this.badLogginAttemp = true;
        }
      }
    );
  }

  private setPersonInformation(identificacion: string) {
    let persona: Persona = <Persona>{};
    this.personaService.consultarPersonaIdentificacion(identificacion).subscribe({
      next:(data) => persona = data,
      complete:() => this.personaService.setCurrentUser(persona)
    });
  }


  public sesionClose (){
    this.localStorage.deleteFromStorage(this.CurrentUserCC);
    this.cleanFgLogin();
    this.isUserloged = false;
    this.router.navigate(['/']);
  }

  private cleanFgLogin(){
    this.getControlLogin('identificacion').setValue('');
    this.getControlLogin('password').setValue('');
  }

}
