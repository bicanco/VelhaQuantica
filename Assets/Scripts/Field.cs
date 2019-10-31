using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Field : MonoBehaviour
{
    public Cat cat;
    private GameManager gameManager;
    private static Cat[] cats = new Cat[2];
    private static int[] vertexes = new int[2];
    private static Board board;
    private bool alreadyCollapsed = false;
    private int conquerer;
    public int index;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        board =  this.transform.GetComponentInParent<Board>();
        index = ArrayUtility.IndexOf(board.GetComponentsInChildren<Field>(),this);
    }

    private void OnMouseDown() {
        if(gameManager.GetCollapse()) {
            if( vertexes[0] == index || vertexes[1] == index ) {
                gameManager.GetPlays();
                Cat[] cats = this.transform.GetComponentsInChildren<Cat>();
                // if( ArrayUtility.IndexOf(cats, cats[0]) == -1) {
                    cats[1].brother.RemoveBrother();
                    cats[1].Conquer();
                    gameManager.EndCollapse();
                // }else{
                //     Cat.RemoveBrothers(cats[0], cats[1]);
                //     board.graph.removeEdge(vertexes[0], vertexes[1]);
                //     cats[1].Conquer();
                // }
            } else {
                print("Não é possível!");
            }
            return;
        } else if(PossibleToPlay()) {
            int aux = gameManager.GetPlays();
            cats[aux] = Cat.Instantiate(this.cat,this.transform.Find("Cats").transform, gameManager.GetPlayersTurn(), gameManager.GetTurn());
            vertexes[aux] = index;
            if(aux == 0){
                board.connect(vertexes[0],vertexes[1]);
                Cat.SetBrothers(cats[0],cats[1]);
                board.VerifyCycle(index);
                cats = new Cat[2];
            }
        } else {
            print("Já jogou aqui!");
        }
    }

    private bool PossibleToPlay() {
        bool samefield = false;
        if(cats[1] != null) {
            samefield = cats[1].transform.parent.parent.gameObject == this.gameObject;
        }
        return !alreadyCollapsed && !samefield;
    }

    public void SetAlreadyCollapsed(int player) {
        conquerer = player;
        alreadyCollapsed = true;
    }

    public int GetConquerer() {
        return alreadyCollapsed ? conquerer : -1;
    }   
}
