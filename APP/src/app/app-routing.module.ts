import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TreinoComponent } from './modules/treino/treino.component';
import { LoginComponent } from './modules/autenticacao/login/login.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'treino', component: TreinoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
