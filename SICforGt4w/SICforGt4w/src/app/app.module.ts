import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { NgxMaskModule } from 'ngx-mask'
import { FormsModule } from '@angular/forms';
import { Route } from './app.routes'
import { AppComponent } from './app.component';
import { TopComponent } from './top/top.component';
import { ClienteformComponent } from './clienteform/clienteform.component';
import { FooterComponent } from './footer/footer.component';
import { ListclienteComponent } from './listcliente/listcliente.component';
import { HomeComponent } from './home/home.component';
import swal from 'sweetalert2'
import { AngularFontAwesomeModule } from 'angular-font-awesome';
@NgModule({
  declarations: [
    AppComponent,
    TopComponent,
    ClienteformComponent,
    FooterComponent,
    ListclienteComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(Route),
    NgxMaskModule.forRoot(),
    AngularFontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
