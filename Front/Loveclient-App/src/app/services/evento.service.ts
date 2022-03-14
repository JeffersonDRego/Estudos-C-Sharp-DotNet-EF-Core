import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';


@Injectable(
  // {providedIn: 'root'}
  )
export class EventoService {
baseURL= 'https://localhost:5001/api/eventos'

constructor(private http: HttpClient) { }

  getEventos(): Observable<Evento[]>{
    return this.http.get<Evento[]>(this.baseURL)
  }

  getEventosByTitulo(titulo: string): Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/${titulo}/titulo`)
  }

  getEventoById(id: number ): Observable<Evento>{
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }
}
