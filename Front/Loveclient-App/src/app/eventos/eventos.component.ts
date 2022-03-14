import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
  // providers:[EventoService]
})
export class EventosComponent implements OnInit {

  eventos: Evento[] = [];
  eventosFiltrados: Evento[] = [];

  exibirImagem: boolean = true;
  private _filtroLista: string = '';

  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
  filtrarEventos(filtrarPor: string):Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { titulo: string; local: string; }) => evento.titulo.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor)!== -1
    )
  }

  constructor(private eventoService: EventoService) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public alterarImagem(){
    this.exibirImagem =!this.exibirImagem;
  }

  public getEventos(): void{
    this.eventoService.getEventos().subscribe(
      (_eventos: Evento[]) =>{
        this.eventos = _eventos;
        this.eventosFiltrados= this.eventos;
      },
      error => console.log(error)
    );
  }

}
