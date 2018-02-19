import { Component, Output, OnDestroy, EventEmitter } from '@angular/core'

@Component({
    selector : 'app-top',
    templateUrl : './top.component.html',
    styleUrls:['./top.component.css']
})

export class TopComponent  {

    @Output() public CadastroCliente:EventEmitter<string> = new EventEmitter(); 
}