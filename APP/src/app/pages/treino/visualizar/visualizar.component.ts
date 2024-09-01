import { Component } from '@angular/core';

@Component({
  standalone:true,
  selector: 'app-visualizar',
  templateUrl: './visualizar.component.html',
  styleUrl: './visualizar.component.css'
})
export class VisualizarComponent {
  public cardTitulo: string = "Abs Canivete";
  public cardDescricao: string = `
  <p>O abdominal canivete é um exercício de fortalecimento do core que trabalha principalmente
  os músculos abdominais retos e os flexores do quadril. Durante a execução, o corpo assume
  uma posição em "V", com os braços e pernas estendidos, simulando o movimento de um canivete
  se fechando.</p>

  <p>Para realizá-lo:</p>
  <ol>
    <li>Deite-se de costas, com os braços estendidos acima da cabeça e as pernas esticadas.</li>
    <li>Simultaneamente, eleve os braços e as pernas, tentando tocar as mãos nos pés,
        formando um "V" com o corpo.</li>
    <li>Controle a descida, voltando à posição inicial com cuidado, sem deixar as pernas ou
        os braços tocarem o chão.</li>
  </ol>

  <p>Esse exercício exige força abdominal e flexibilidade, e é importante manter a execução lenta
  e controlada para evitar lesões.</p>`;
  public quantidadeRepeticoesConcluidas: number = 4;
  public quantidadeRepeticoesRealizadas: number = 0;
  public intervalo: number = 30;

  constructor() {
    
  }
}
