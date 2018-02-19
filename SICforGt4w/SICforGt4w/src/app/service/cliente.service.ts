import { Http, RequestOptions, Headers } from '@angular/http';
import { Injectable } from '@angular/core';
import { Cliente } from '../../shared/cliente/cliente.model'
import 'rxjs/add/operator/toPromise'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { Observable } from 'rxjs/Observable';
import { Router, ActivatedRoute } from '@angular/router';
import { Route } from '@angular/router/src/config';
import swal from 'sweetalert2'

@Injectable()
export class ClienteService {
    constructor(private http: Http, private router: Router) {

    }

    public getAll(): Promise<Array<Cliente>> {

        return this.http.get('http://sicsystemwebapi.gear.host/Cliente/GetList')
            .map((response: any) => {
                return response.json().data.map(cliente => {
                    return new Cliente(cliente.Id, cliente.Nome, cliente.Cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "\$1.\$2.\$3\-\$4"), new Date(parseInt(cliente.DataNascimento.substr(6))), cliente.Peso, cliente.Estado, )
                });
            })
            .toPromise();

    }
    public getById(codCliente: number): Promise<Cliente> {

        return this.http.get(`http://sicsystemwebapi.gear.host/Cliente/Details/${codCliente}`)
            .map((response: any) => {
                try {
                if (response.json().status === 200) {
                  
                    return new Cliente(response.json().data.Id, response.json().data.Nome, response.json().data.Cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "\$1.\$2.\$3\-\$4"),
                    new Date(parseInt(response.json().data.DataNascimento.substr(6))), response.json().data.Peso, response.json().data.Estado)
                }
                else {

                    swal({ title: response.json().message, type: "error" })
                }

               
                }
                catch{
                    return null;
                }
                ;

            })
            .toPromise();

    }

    public create(cliente: Cliente): Observable<any> {
        let headers: Headers = new Headers();
        return this.http.post("http://sicsystemwebapi.gear.host/Cliente/Create", cliente, new RequestOptions({ headers: headers }))
            .map((response: any) => {


                response.json();

                if (response.json().status === 200) {
                    swal({ title: response.json().message, type: "success" })
                    this.router.navigateByUrl('/Listar')

                }
                else {

                    swal({ title: response.json().message, type: "error" })
                }
            }
            )

    }

    public edit(cliente: Cliente): Observable<any> {
        let headers: Headers = new Headers();
        return this.http.post("http://sicsystemwebapi.gear.host/Cliente/Edit", cliente, new RequestOptions({ headers: headers }))
            .map((response: any) => {


                response.json();

                if (response.json().status === 200) {
                    swal({ title: response.json().message, type: "success" })
                    this.router.navigateByUrl('/Listar')

                }
                else {

                    swal({ title: response.json().message, type: "error" })
                }
            })
    }

    public delete(codCliente: number): Observable<any> {
        let headers: Headers = new Headers();
        return this.http.post(`http://sicsystemwebapi.gear.host/Cliente/Delete?id=${codCliente}`, new RequestOptions({ headers: headers }))
            .map((response: any) => {


                response.json();
                if (response.json().status === 200) {
                    swal({ title: response.json().message, type: "success" })               

                }
                else {

                    swal({ title: response.json().message, type: "error" })
                }
            })
    }
    public checkCpf(cpfCliente: string): Promise<Boolean> {

        return this.http.get(`http://sicsystemwebapi.gear.host/Cliente/CheckCpf?cpf=${cpfCliente}`)
            .toPromise()
            .then((response: any) => {
                if (response.json().data.length > 0) {
                    swal({ title: "CPF já cadastrado!", type: "warning" })
                }

                return response.json().data.length > 0
            })
            ;

    }


}