import { Routes } from '@angular/router'
import { HomeComponent } from './home/home.component'
import { ClienteformComponent } from "./clienteform/clienteform.component"
import { ListclienteComponent } from "./listcliente/listcliente.component"

export const Route: Routes = [
    { path: '', component: HomeComponent },
    { path: 'Listar', component: ListclienteComponent },
    { path: 'Cadastro', component: ClienteformComponent },
    { path: 'Visualizar/:id', component: ClienteformComponent },
    { path: 'Editar/:id', component: ClienteformComponent }
]