import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  exibirImagem: boolean = true;
  private _filtroLista: string = '';
  public eventosFiltrados: any = [];


  public get filtroLista(): string{
    return this._filtroLista;
  }
  public set filtroLista(value){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
  filtrarEventos(filtrarPor: string):any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { titulo: string; local: string; }) => evento.titulo.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor)!== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  alterarImagem(){
    this.exibirImagem =!this.exibirImagem;
  }

  public getEventos(): void{

    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response =>{
        this.eventos = response;
        this.eventosFiltrados= this.eventos;
      },
      error => console.log(error)
    );
  }

}
