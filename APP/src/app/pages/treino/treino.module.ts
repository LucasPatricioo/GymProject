import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreinoComponent } from './treino.component';
import { VisualizarComponent } from './visualizar/visualizar.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { SeletorTemaComponent } from '../../shared/components/seletor-tema/seletor-tema.component';



@NgModule({
  declarations: [
    TreinoComponent,
  ],
  imports: [
    CommonModule,
    VisualizarComponent,
    CadastroComponent,
    SeletorTemaComponent
  ]
})
export class TreinoModule { }
