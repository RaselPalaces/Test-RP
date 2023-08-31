import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
import { OrdenReparacion } from 'src/app/entidades/orden-reparacion';

@Injectable({
  providedIn: 'root'
})
export class OrdenReparacionService {

  PATH_BACKEND = "http://localhost:" + "5202"

  URL_GET = this.PATH_BACKEND + "/api/OrdenReparacion/GetAllOrdenReparacion";
  URL_ADD_ORDEN = this.PATH_BACKEND + "/api/OrdenReparacion/AddOrdenReparacion";

  constructor(private httpClient: HttpClient) {
  }

  public GetAll(): Observable<HttpResponse<any>> {
    return this.httpClient
      .get<any>(this.URL_GET,
        { observe: 'response' })
      .pipe();
  }

  public Add(entidad: OrdenReparacion): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_ORDEN, entidad,
        { observe: 'response' })
      .pipe();
  }

}