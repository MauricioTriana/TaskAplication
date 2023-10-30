import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Tarea } from '../entities/tarea';
import { Categoria } from '../entities/categoria';

@Injectable({
  providedIn: 'root'
})
export class TareaService {

  constructor(private http: HttpClient) { }
  
  private baseUrl: string = 'http://localhost:11368/api/Tarea';
  private baseUrlCategoria: string = 'http://localhost:11368/api/Categoria';
  
  public consultarTarea( id: number ): Observable<any>{
    return this.http.get(`${this.baseUrl}/${id}`);
  }

  public consultarTareas(): Observable<any>{
    return this.http.get(`${this.baseUrl}/GetAll`);
  }

  public insertarTarea( tarea: Tarea ): Observable<any>{
    return this.http.post(`${this.baseUrl}`,tarea);
  }

  public actualizarTarea( tarea: Tarea ): Observable<any>{
    return this.http.put(`${this.baseUrl}`,tarea);
  }

  public eliminarTarea( id: number ): Observable<any>{
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  public consultarCategorias(): Observable<Array<Categoria>>{
    return this.http.get<Array<Categoria>>(`${this.baseUrlCategoria}/GetAll`);
  }

  public consultarCategoria(id: number): Observable<Categoria>{
    return this.http.get<Categoria>(`${this.baseUrlCategoria}/${id}`);
  }

}
