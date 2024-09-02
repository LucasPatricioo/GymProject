import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TreinoComponent } from './pages/treino/treino.component';
import { LoginComponent } from './pages/usuario/login/login.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'treino', component: TreinoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
