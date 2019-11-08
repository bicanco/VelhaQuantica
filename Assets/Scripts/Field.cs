using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public Cat cat;
    private GameManager gameManager;
    private TemporaryPosition temporaryPositions;
    private static Cat[] cats = new Cat[2];
    private static int[] vertexes = new int[2];
    private static Board board;
    private bool alreadyCollapsed = false;
    private int conquerer;
    private int next = 0;
    public int index;
    public Sprite glow;
    public SpriteRenderer balaojogou;
    public SpriteRenderer balaoinvalida;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        board =  this.transform.GetComponentInParent<Board>();
        temporaryPositions = this.GetComponentInChildren<TemporaryPosition>();
        index = ArrayUtility.IndexOf(board.GetComponentsInChildren<Field>(),this);
    }

    void showbalaojogou()
    {
        balaojogou.enabled = true;
    }

    void hidebalaojogou()
    {
        balaojogou.enabled = false;  
    }

    void showbalaoinvalida()
    {
        balaoinvalida.enabled = true;
    }

    void hidebalaoinvalida()
    {
        balaoinvalida.enabled = false;  
    }

    private void OnMouseDown() {
        if(gameManager.GetCollapse()) {
            if( vertexes[0] == index || vertexes[1] == index ) {
                gameManager.GetPlays();
                Cat[] cats = this.transform.GetComponentsInChildren<Cat>();
                transform.Find("TemporaryPositions").gameObject.SetActive(false);
                cats[1].brother.RemoveBrother();
                cats[1].Conquer();
                gameManager.EndCollapse();
            } else {
                showbalaoinvalida();
                print("Não é possível!");
            }
            return;
        } else if(PossibleToPlay()) {
            hidebalaojogou();
            hidebalaoinvalida();
            int aux = gameManager.GetPlays();
            int playerTurn = gameManager.GetPlayersTurn();
            int turn = gameManager.GetTurn();
            cats[aux] = Cat.Instantiate(this.cat,this.transform.Find("Cats").transform, playerTurn, turn, GetNext());
            vertexes[aux] = index;
            UpdateNext();
            if(aux == 0){
                board.connect(vertexes[0],vertexes[1]);
                Cat.SetBrothers(cats[0],cats[1]);
                if(board.VerifyCycle(index)){
                    cats[0].GetMiniCat().SetGlow(glow);
                    cats[1].GetMiniCat().SetGlow(glow);
                }
                cats = new Cat[2];
            }
        } else {
            showbalaojogou();
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

    public GameObject GetNext() {
        return transform.GetChild(1).GetChild(next).gameObject;
    }

    public GameObject GetCurrent() {
        return transform.GetChild(1).GetChild( next - 1 ).gameObject;
    }

    private void UpdateNext() {
        next++;
    }

    public void DeactivateTP() {
        temporaryPositions.gameObject.SetActive(false);
    }
}
