import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SeletorTemaComponent } from '../../shared/components/seletor-tema/seletor-tema.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    SeletorTemaComponent,
    FormsModule,
    RouterModule
  ]
})
export class UsuarioModule { }
