import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreinoComponent } from './treino.component';
import { VisualizarComponent } from './visualizar/visualizar.component';
import { CadastroComponent } from './cadastro/cadastro.component';



@NgModule({
  declarations: [
    TreinoComponent,
  ],
  imports: [
    CommonModule,
    VisualizarComponent,
    CadastroComponent
  ]
})
export class TreinoModule { }
