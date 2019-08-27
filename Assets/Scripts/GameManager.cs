using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool playersTurn = false;
    private int turn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPlayersTurn(){
        bool temp = this.playersTurn;
        this.playersTurn = !this.playersTurn;
        return temp ? 1 : 0;
    }

    public int GetTurn(){
        return this.turn++;
    }
}
