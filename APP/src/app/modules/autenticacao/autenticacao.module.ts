import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { SeletorTemaComponent } from '../../shared/components/seletor-tema/seletor-tema.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegistroComponent
  ],
  imports: [
    CommonModule,
    SeletorTemaComponent,
    FormsModule,
    RouterModule
  ]
})
export class AutenticacaoModule { }
