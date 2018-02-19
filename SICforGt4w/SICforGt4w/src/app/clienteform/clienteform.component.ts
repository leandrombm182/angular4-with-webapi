import { Component, OnInit, OnDestroy, EventEmitter } from '@angular/core';
import { Estado } from '../../shared/estado/estado.model';
import { EstadoService } from '../service/estados.service';
import { Cliente } from '../../shared/cliente/cliente.model';
import { ClienteService } from '../service/cliente.service';
import { NgForm, Validators, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Route } from '@angular/router/src/config';
import swal from 'sweetalert2';

@Component({
  selector: 'app-clienteform',
  templateUrl: './clienteform.component.html',
  styleUrls: ['./clienteform.component.css'],
  providers: [EstadoService, ClienteService]
})
export class ClienteformComponent implements OnInit, OnDestroy {
  public title: string = "Cadastro"
  public statusoperacao: Boolean = false;
  public cliente: Cliente = new Cliente();
  public bloquearCampos: Boolean;
  constructor(private estadoService: EstadoService, private clienteService: ClienteService,
    private router: Router, private route: ActivatedRoute) {

  }

  public countries: Array<Estado> = [];

  ngOnInit() {


    this.estadoService.getEstados()
      .then((estados: Array<Estado>) => {
        this.countries = estados;
      })
    this.route.params.subscribe(params => {
      if (params['id'])
        this.clienteService.getById(params['id'])
          .then((cliente: Cliente) => {
            if (cliente) {
              this.cliente = cliente;
              this.bloquearCampos = this.router.url.indexOf("Visualizar") > 0
              this.title = this.router.url.indexOf("Visualizar") > 0 ? "Visualizar" : "Editar";

            }

          })
    });


  }
  ngOnDestroy() { }


  public cadastrarCliente(formulario: NgForm): void {
    let cliente: Cliente = new Cliente(formulario.value.Id, formulario.value.Nome, formulario.value.Cpf, formulario.value.DataNascimento, formulario.value.Peso, formulario.value.Estado)
    this.clienteService.create(cliente)
      .subscribe((response: any) => {

      }
      )
  }
  public editarCliente(formulario: NgForm): void {
    let cliente: Cliente = new Cliente(formulario.value.Id, formulario.value.Nome, formulario.value.Cpf, formulario.value.DataNascimento, formulario.value.Peso, formulario.value.Estado)
    this.clienteService.edit(cliente)
      .subscribe((response: any) => {
      }
      )
  }
  public CheckCpf(event: Event): void {
    let cpf: string = (<HTMLInputElement>event.target).value.replace(/(\.|\/|\-)/g, "")
    if (this.validaCPF(cpf)) {
      this.clienteService.checkCpf(cpf)
        .then((response: Boolean) => {

        })

    }
    else {

      swal({ title: "CPF Inválido!", type: "error" })
    }
  }
  private validaCPF(cpf: String) {
    var numeros, digitos, soma, i, resultado, digitos_iguais;
    digitos_iguais = 1;
    if (cpf.length < 11)
      return false;
    for (i = 0; i < cpf.length - 1; i++)
      if (cpf.charAt(i) != cpf.charAt(i + 1)) {
        digitos_iguais = 0;
        break;
      }
    if (!digitos_iguais) {
      numeros = cpf.substring(0, 9);
      digitos = cpf.substring(9);
      soma = 0;
      for (i = 10; i > 1; i--)
        soma += numeros.charAt(10 - i) * i;
      resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
      if (resultado != digitos.charAt(0))
        return false;
      numeros = cpf.substring(0, 10);
      soma = 0;
      for (i = 11; i > 1; i--)
        soma += numeros.charAt(11 - i) * i;
      resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
      if (resultado != digitos.charAt(1))
        return false;
      return true;
    }
    else
      return false;
  }



}
