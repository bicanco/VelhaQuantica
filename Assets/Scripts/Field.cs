using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public Cat cat;
    private GameManager gameManager;
    private GameObject temporaryPositions;
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
        temporaryPositions = this.transform.Find("TemporaryPositions").gameObject;
        index = System.Array.FindIndex(board.GetComponentsInChildren<Field>(), (Field field) => {
            return field == this;
        });
    }

    // Avisando jogador já jogou aqui
    void showbalaojogou()
    {
        balaojogou.enabled = true;
    }

    // Escondendo aviso já jogou aqui
    void hidebalaojogou()
    {
        balaojogou.enabled = false;  
    }

    // Avisando jogador local inválido
    void showbalaoinvalida()
    {
        balaoinvalida.enabled = true;
    }

    // Escondendo aviso local inválido
    void hidebalaoinvalida()
    {
        balaoinvalida.enabled = false;  
    }

    private void OnMouseDown() {
        // se houver ciclo para colapsar
        if(gameManager.GetCollapse()) {
            // se for uma posição válida para colapsar
            if( vertexes[0] == index || vertexes[1] == index ) {
                gameManager.GetPlays();
                Cat[] temp = this.transform.GetComponentsInChildren<Cat>();
                int toCollapse = temp.Length - 1;
                transform.Find("TemporaryPositions").gameObject.SetActive(false);
                temp[toCollapse].brother.RemoveBrother();
                temp[toCollapse].Conquer();
                gameManager.EndCollapse();
            } else {
                showbalaoinvalida();
            }
            return;
        // se for uma posição válida para adicionar um gato
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
                board.Connect(vertexes[0],vertexes[1]);
                Cat.SetBrothers(cats[0],cats[1]);
                if(board.VerifyCycle(index)){
                    cats[0].GetMiniCat().SetGlow(glow);
                    cats[1].GetMiniCat().SetGlow(glow);
                }
                cats = new Cat[2];
            }
        } else {
            showbalaojogou();
        }
    }

    // verificando se é possível jogar neste campo
    private bool PossibleToPlay() {
        bool samefield = false;
        if(cats[1] != null) {
            samefield = cats[1].transform.parent.parent.gameObject == this.gameObject;
        }
        return !alreadyCollapsed && !samefield;
    }

    // marcando o campo como já colapsado
    public void SetAlreadyCollapsed(int player) {
        conquerer = player;
        alreadyCollapsed = true;
    }

    // obtendo que jogador  ganhou este espaço
    public int GetConquerer() {
        return alreadyCollapsed ? conquerer : -1;
    }

    // obtendo proxima posição dos gatos pequenos
    public GameObject GetNext() {
        return transform.GetChild(1).GetChild(next).gameObject;
    }

    // obtendo última posição em que foi adicionado um gato pequeno
    public GameObject GetCurrent() {
        return transform.GetChild(1).GetChild( next - 1 ).gameObject;
    }

    // atualizando a próxima posição a ser preenchida
    private void UpdateNext() {
        next++;
    }

    public void DeactivateTP() {
        temporaryPositions.gameObject.SetActive(false);
    }
}
