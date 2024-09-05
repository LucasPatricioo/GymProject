import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TreinoModule } from './modules/treino/treino.module';
import { SeletorTemaComponent } from './shared/components/seletor-tema/seletor-tema.component';
import { UsuarioModule } from './modules/usuario/usuario.module';
import { HttpClientModule } from '@angular/common/http';
import { AutenticacaoModule } from './modules/autenticacao/autenticacao.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UsuarioModule,
    AutenticacaoModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
