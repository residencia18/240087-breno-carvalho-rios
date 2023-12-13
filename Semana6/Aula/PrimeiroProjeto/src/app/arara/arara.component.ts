import { Component } from "@angular/core";

@Component({
    selector: 'app-arara',
    templateUrl: 'arara.component.html',
    styleUrls: ['arara.component.css']
})

export class AraraComponent {
    nome: string = 'Arara'
    link: string = "https://pt.wikipedia.org/wiki/Arara-azul-grande"
    target: string = "_blank"

    public onchange() {
        alert("Input mudou de valor!")
    }
}