import { Component, signal } from '@angular/core'; //Component permite declarar classe com angular & o signal permite atualizar interface após guardar valores. 
import { RouterOutlet } from '@angular/router'; //Router outlet permite ao angular apresentar comps associadas ás rotas!

@Component({
  imports: [RouterOutlet], //dependencias no template
  selector: 'app-root', // etiqueta html do comp
  styleUrl: './app.css', // css
  templateUrl: './app.html', //file html associado
})
export class App {
  protected readonly title = signal('TaskFlow-web'); //propria classe only, impedindo alterações+ signal 
}
