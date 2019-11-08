using UnityEngine;

public class Cat: MonoBehaviour
{
    private int owner;
    private int index;
    private CatImage catImage;
    private GameManager gameManager;
    private Field parent;
    public Cat brother;
    private Board board;
    public Sprite[] catSprites = new Sprite[2];
    public Sprite[] numberSprites = new Sprite[36];

    void Awake(){
        parent = this.transform.parent.parent.GetComponent<Field>();
        catImage = this.transform.Find("catImage").GetComponent<CatImage>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        board = GameObject.Find("board").GetComponent<Board>();
        catImage.gameObject.SetActive(false);
    }

    public void Conquer() {
        catImage.gameObject.SetActive(true);
        parent.SetAlreadyCollapsed(owner);
        parent.DeactivateTP();
        foreach (Cat cat in this.transform.parent.GetComponentsInChildren<Cat>())
        {
            if(cat.gameObject != this.gameObject) {
                if(cat.brother != null){
                    cat.brother.RemoveBrother();
                    cat.brother.Conquer();
                }
                Object.Destroy(cat.gameObject);
            }
        }
    }

    private void SetSprite(int cat, int number, GameObject minicat) {
        index = number;
        owner = cat;
        Sprite catSprite = catSprites[cat];
        Sprite numberSprite = numberSprites[number-1];
        catImage.SetSprite(catSprite, numberSprite);
        minicat.GetComponent<CatImage>().SetSprite(catSprite, numberSprite);
    }

    public static void SetBrothers(Cat cat1, Cat cat2) {
        cat1.brother = cat2;
        cat2.brother = cat1;
    }

    public void RemoveBrother() {
        if(brother != null){
            board.graph.removeEdge(
                this.gameObject.transform.parent.parent.GetComponent<Field>().index,
                brother.gameObject.transform.parent.parent.GetComponent<Field>().index
            );
        }
        brother = null;
    }
    public static Cat Instantiate(Cat cat, Transform position, int sprite, int index, GameObject miniCat){
        Cat temp = Instantiate(cat, position, false);
        temp.SetSprite(sprite, index, miniCat);
        return temp;
    }

    public CatImage GetMiniCat() {
        return parent.GetComponent<Field>().GetCurrent().GetComponent<CatImage>();
    }
}
