import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { Estado } from "../../shared/estado/estado.model";
import 'rxjs/add/operator/toPromise'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';


@Injectable()
export class EstadoService {

    constructor(private http: Http) {

    }
    public getEstados(): Promise<Array<Estado>> {
        return this.http.get('http://www.geonames.org/childrenJSON?geonameId=3469034')
            .map((response: any) => {
                
                return response.json().geonames.map(estado => {
                    return new Estado(`${estado.adminCodes1.ISO3166_2} - ${estado.adminName1}`, estado.adminCodes1.ISO3166_2)
                });
            })
            .toPromise();     



    }
}