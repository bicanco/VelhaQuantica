using UnityEngine;

public class Field : MonoBehaviour
{
    public Cat cat;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown() {
        Cat instantiatedCat = Instantiate(this.cat, this.transform.Find("Cats").transform, false);
        instantiatedCat.SetSprite(gameManager.GetPlayersTurn());
        instantiatedCat.SetIndex(gameManager.GetTurn());
        this.transform.GetComponentInParent<Board>().VerifyCicle();
    }
    
}
