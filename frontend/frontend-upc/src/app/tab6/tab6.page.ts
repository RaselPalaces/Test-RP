import { Component } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { OrdenReparacion } from '../entidades/orden-reparacion';
import { OrdenReparacionService } from '../servicios-backend/orden-reparacion/orden-reparacion.service';

@Component({
  selector: 'app-tab6',
  templateUrl: 'tab6.page.html',
  styleUrls: ['tab6.page.scss']
})
export class Tab6Page {

  public numeroOrden  = ""
  public costoEstimado = 1
  public idEquipoMedico  = 1
  public idUsuario  = 1
  
  public listaOrden: OrdenReparacion[] = []

  constructor(private ordenReparacionService: OrdenReparacionService) {
    this.getOrdenFromBackend();
  }

  private getOrdenFromBackend(){
    this.ordenReparacionService.GetAll().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaOrden = response.body;
            console.log(this.listaOrden)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
    });
  }

  public addOrden(){
   this.AddOrdenFromBackend(this.numeroOrden, this.costoEstimado, this.idEquipoMedico, this.idUsuario)
  }

  private AddOrdenFromBackend(numeroOrden: string, costoEstimado: number, idEquipoMedico: number, idUsuario: number){

    var usuarioEntidad = new OrdenReparacion();
    usuarioEntidad.numeroOrden = numeroOrden;
    usuarioEntidad.costoEstimado = costoEstimado;
    usuarioEntidad.idEquipoMedico = idEquipoMedico;
    usuarioEntidad.idUsuario = idUsuario;

    this.ordenReparacionService.Add(usuarioEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego el ORDEN con exito :)");
              this.getOrdenFromBackend();//Se actualize el listado
              this.numeroOrden = "";
              this.costoEstimado = 1;
              this.idEquipoMedico = 1;
              this.idUsuario = 1;
          }else{
              alert("Al agregar el ORDEN fallo exito :(");
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
