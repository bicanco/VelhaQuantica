using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool playerOfTurn = true;
    private bool plays = false;
    private int turn = 0;
    private bool collapse = false;
    private Board board;

    void Start()
    {
        board = GameObject.Find("board").GetComponent<Board>();
    }


    // obtendo a jogada atual do jogador da vez
    public int GetPlays(){
        plays = !plays;
        return plays ? 1 : 0;
    }

    // obtendo o jogador da vez
    public int GetPlayersTurn(){
        if(plays)
            playerOfTurn = !playerOfTurn;
        return playerOfTurn ? 1 : 0;
    }

    // obtendo o turno do jogo
    public int GetTurn(){
        if(plays)
            turn++;
        return turn;
    }

    // ativando preparação para colapsar
    public void SetCollapse(){
        collapse = true;
        plays = !plays;
    }

    // finalizando o colapso
    public void EndCollapse() {
        Board.BoardState state = board.GetState();
        //Verificando se há empate, vitória ou não acabou o jogo
        if(state == Board.BoardState.Draw){
            SceneManager.LoadScene(3);
        }else if(state == Board.BoardState.BlackVictory){
            SceneManager.LoadScene(4);
        }else if(state == Board.BoardState.OrangeVictory){
            SceneManager.LoadScene(5);
        }
        collapse = false;
    }

    // obtendo se há um calapso pronto para acontecer
    public bool GetCollapse(){
        return collapse;
    }
}
