import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { EquipoMedico } from 'src/app/entidades/equipo-medico';

@Injectable({
  providedIn: 'root'
})
export class EquipoMedicoService {

  PATH_BACKEND = "http://localhost:" + "5202"

  URL_GET = this.PATH_BACKEND + "/api/EquipoMedico/GetAllEquipoMedico";
  URL_ADD_EQUIPO = this.PATH_BACKEND + "/api/EquipoMedico/AddEquipoMedico";

  constructor(private httpClient: HttpClient) {
  }

  public GetAll(): Observable<HttpResponse<any>> {
    return this.httpClient
      .get<any>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

  public Add(entidad: EquipoMedico): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_EQUIPO, entidad,
        { observe: 'response' })
      .pipe();
  }

}