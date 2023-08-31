import { Component } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { EquipoMedico } from '../entidades/equipo-medico';
import { EquipoMedicoService } from '../servicios-backend/equipo-medico/equipo-medico.service';

@Component({
  selector: 'app-tab5',
  templateUrl: 'tab5.page.html',
  styleUrls: ['tab5.page.scss']
})
export class Tab5Page {

  public nombreEquipo = ""
  public descripcionProblema = ""
  public estadoReparacion = ""

  public listaEquipo: EquipoMedico[] = []

  constructor(private equipoMedicoService: EquipoMedicoService) {
/*
    let usuario: Usuarios = new Usuarios();
    usuario.nombreCompleto = "Eddy Escalante"
    usuario.userName = "eescalante"
    usuario.password = "2023"

    this.listaUsuarios.push(usuario)
    this.listaUsuarios.push(usuario)
*/
    this.getUsuariosFromBackend();
  }

  private getUsuariosFromBackend(){
    this.equipoMedicoService.GetAll().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaEquipo = response.body;
            console.log(this.listaEquipo)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
    });
  }

  public addEquipoMedico(){
  this.AddEquipoMedicoFromBackend(this.nombreEquipo, this.descripcionProblema, this.estadoReparacion)
  }

  private AddEquipoMedicoFromBackend(nombreEquipo: string, descripcionProblema: string, estadoReparacion: string){

    var usuarioEntidad = new EquipoMedico();
    usuarioEntidad.nombreEquipo = nombreEquipo;
    usuarioEntidad.descripcionProblema = descripcionProblema;
    usuarioEntidad.estadoReparacion = estadoReparacion;

    this.equipoMedicoService.Add(usuarioEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego el EQUIPO con exito :)");
              this.getUsuariosFromBackend();//Se actualize el listado
              this.nombreEquipo = "";
              this.descripcionProblema = "";
              this.estadoReparacion = "";
          }else{
              alert("Al agregar el EQUIPO fallo exito :(");
          }
      },
      error: (error: any) => {
          console.log(error);
      },
      complete: () => {
          //console.log('complete - this.AddUsuario()');
      },
  });
  }

}