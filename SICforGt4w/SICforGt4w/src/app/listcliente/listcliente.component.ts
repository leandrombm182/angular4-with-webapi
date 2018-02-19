import { Component, OnInit, OnDestroy, EventEmitter  } from '@angular/core';
import { ClienteService } from '../service/cliente.service';
import { Cliente } from '../../shared/cliente/cliente.model';
import swal from 'sweetalert2'

@Component({
  selector: 'app-listcliente',
  templateUrl: './listcliente.component.html',
  styleUrls: ['./listcliente.component.css'],
  providers: [ClienteService]
})
export class ListclienteComponent implements OnInit {

  public clientes: Array<Cliente>;
  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.clienteService.getAll()
    .then((clientesList: Array<Cliente>) => {
      this.clientes = clientesList;
    })

  }
  public deletarCliente(codCliente: number): void {
    this.clienteService.delete(codCliente)
      .subscribe((response: any) => {        
          this.clienteService.getAll()
          .then((clientesList: Array<Cliente>) => {
            this.clientes = clientesList;
          })

      }
      )
  }
}
