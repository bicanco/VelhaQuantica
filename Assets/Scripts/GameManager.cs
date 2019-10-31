using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        
    }

    public int GetPlays(){
        plays = !plays;
        return plays ? 1 : 0;
    }

    public int GetPlayersTurn(){
        if(plays)
            playerOfTurn = !playerOfTurn;
        return playerOfTurn ? 1 : 0;
    }

    public int GetTurn(){
        if(plays)
            turn++;
        return turn;
    }

    public void SetCollapse(){
        collapse = true;
        plays = !plays;
    }

    public void EndCollapse() {
        Board.BoardState state = board.GetState();
        if(state == Board.BoardState.Draw){
            // go to draw scene
            print("draw");
        }else if(state == Board.BoardState.BlackVictory){
            // go to victory scene
            print("victory black");
        }else if(state == Board.BoardState.OrangeVictory){
            // go to victory scene
            print("victory orange");
        }
        collapse = false;
    }

    public bool GetCollapse(){
        return collapse;
    }
}
