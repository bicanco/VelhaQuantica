using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool playerOfTurn = true;
    private bool plays = false;
    private int turn = 0;

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
        // bool temp = this.playersTurn;
        // this.playersTurn = !this.playersTurn;
        return playerOfTurn ? 1 : 0;
    }

    public int GetTurn(){
        if(plays)
            turn++;
        return turn;
    }
}
