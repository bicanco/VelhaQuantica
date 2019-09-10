using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Field : MonoBehaviour
{
    public Cat cat;
    private GameManager gameManager;
    // private static Cat[] cats = new Cat[2];
    private static int[] cats = new int[2];
    private static Board board;
    private int index;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        board =  this.transform.GetComponentInParent<Board>();
        index = ArrayUtility.IndexOf(board.GetComponentsInChildren<Field>(),this);
    }

    private void OnMouseDown() {
        int aux = gameManager.GetPlays();
        Cat.Instantiate(this.cat,this.transform.Find("Cats").transform, gameManager.GetPlayersTurn(), gameManager.GetTurn());
        cats[aux] = index;
        if(aux == 0){
            board.connect(cats[0],cats[1]);
            // Cat.SetBrothers(cats[0],cats[1]);
            board.VerifyCicle();
        }
    }
    
}
