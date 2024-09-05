import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../../services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  public email: string = "";
  public senha: string = "";

  constructor(private apiService: UsuarioService) { }

  data: any;

  ngOnInit(): void {

    this.apiService.getData(1).subscribe(
      (response) => {
        this.data = response;  // Armazena os dados retornados pela API
        console.log(this.data);
      },
      (error) => {
        console.error('Erro ao acessar a API:', error);
      }
    );
  }


  public logar(): void {
    this.apiService.getData(1).subscribe(
      (response) => {
        this.data = response;
      },
      (error) => {
        console.error('Erro ao acessar a API:', error);
      }
    )


    console.log("teste");
  }
}
