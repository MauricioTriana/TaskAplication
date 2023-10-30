import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { Persona } from '../entities/persona'

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  
  constructor(private http: HttpClient) { }
  private baseUrl: string = 'http://localhost:11368/api/Persona';
  private _currentUser: Persona = <Persona>{};

  public setCurrentUser(user: Persona) {
    this._currentUser = user;
  }

  public geturrentUser(): Persona {
    return this._currentUser;
  }
 
  public consultarPersona( id: number ): Observable<any>{
    return this.http.get(`${this.baseUrl}/${id}`);
  }

  public consultarPersonaIdentificacion( id: string ): Observable<Persona>{
    return this.http.get<Persona>(`${this.baseUrl}/identificacion/${id}`);
  }

  public consultarPersonas( ): Observable<any>{
    return this.http.get(`${this.baseUrl}/GetAll`);
  }

  public loginPersona( id: string, password: string ): Observable<any>{
    return this.http.get(`${this.baseUrl}/identificacion/${id}/pass/${password}`);
  }
}
