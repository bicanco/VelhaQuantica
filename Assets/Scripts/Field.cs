using UnityEngine;

public class Field : MonoBehaviour
{
    public Cat cat;
    private GameManager gameManager;
    private static Cat[] cats = new Cat[2];
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown() {
        int aux = gameManager.GetPlays();
        cats[aux] = Cat.Instantiate(this.cat,this.transform.Find("Cats").transform, gameManager.GetPlayersTurn(), gameManager.GetTurn());
        if(aux == 0){
            Cat.SetBrothers(cats[0],cats[1]);
            this.transform.GetComponentInParent<Board>().VerifyCicle();
        }
    }
    
}
