using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool playerOfTurn = true;
    private bool plays = false;
    private int turn = 0;
    private bool collapse = false;

    void Start()
    {
        
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
        if(EndGame()){
            // go to final scene
            print("end");
        }
        collapse = false;
    }

    private bool EndGame() {
        return true;
    }
    public bool GetCollapse(){
        return collapse;
    }
}
