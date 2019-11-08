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
    private SpriteRenderer turnSprite;
    public Sprite[] catSprites = new Sprite[2];

    void Start()
    {
        board = GameObject.Find("board").GetComponent<Board>();
        turnSprite = GameObject.Find("cat").GetComponent<SpriteRenderer>();
        turnSprite.sprite = catSprites[0];
    }


    // obtendo a jogada atual do jogador da vez
    public int GetPlays(){
        plays = !plays;
        return plays ? 1 : 0;
    }

    // obtendo o jogador da vez
    public int GetPlayersTurn(){
        if(plays) {
            playerOfTurn = !playerOfTurn;
            turnSprite.sprite = catSprites[playerOfTurn ? 1 : 0 ];
        }else if(collapse){
            turnSprite.sprite = catSprites[playerOfTurn ? 1 : 0 ];
        } else {
            turnSprite.sprite = catSprites[playerOfTurn ? 0 : 1 ];
        }
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
        StartCoroutine(ChangeScene(state));
        collapse = false;
    }

    // Esperando um tempo para mudar de cena se for necessário
    private IEnumerator ChangeScene(Board.BoardState state) {
       if(state == Board.BoardState.Draw){
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(3);
        }else if(state == Board.BoardState.BlackVictory){
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(4);
        }else if(state == Board.BoardState.OrangeVictory){
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(5);
        }
    }

    // obtendo se há um calapso pronto para acontecer
    public bool GetCollapse(){
        return collapse;
    }
}
