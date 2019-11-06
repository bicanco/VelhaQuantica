using UnityEngine;

public class Cat: MonoBehaviour
{
    private int owner;
    private int index;
    private GameObject catSprite;
    private GameObject numberSprite;
    // private SpriteRenderer catSprite;
    // private SpriteRenderer numberSprite;
    private GameManager gameManager;
    private Field parent;
    public Cat brother;
    private Board board;
    public Sprite[] catSprites = new Sprite[2];
    public Sprite[] numberSprites = new Sprite[36];

    void Awake(){
        parent = this.transform.parent.parent.GetComponent<Field>();
        catSprite = this.transform.Find("catSprite").gameObject;
        numberSprite = this.transform.Find("numberSprite").gameObject;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        board = GameObject.Find("board").GetComponent<Board>();
        catSprite.SetActive(false);
        numberSprite.SetActive(false);
    }

    void Start(){
    }

    public void Conquer() {
        catSprite.SetActive(true);
        numberSprite.SetActive(true);
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

    public void SetSprite(int index) {
        parent.GetNext().transform.GetChild(0).GetComponent<SpriteRenderer>().sprite =  this.catSprites[index];
        owner = index;
        this.catSprite.GetComponent<SpriteRenderer>().sprite = this.catSprites[index];
    }

    public void SetIndex(int index){
        parent.GetNext().transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = this.numberSprites[index-1];
        this.index = index;
        this.numberSprite.GetComponent<SpriteRenderer>().sprite = this.numberSprites[index-1];
        
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
    public static Cat Instantiate(Cat cat, Transform position, int sprite, int index){
        Cat temp = Instantiate(cat, position, false);
        temp.SetSprite(sprite);
        temp.SetIndex(index);
        return temp;
    }
    
}
