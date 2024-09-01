import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TreinoComponent } from './pages/treino/treino.component';

const routes: Routes = [
  { path: 'treino', component: TreinoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
