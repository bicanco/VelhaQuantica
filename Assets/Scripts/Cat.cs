using UnityEngine;

public class Cat: MonoBehaviour
{
    private int owner;
    private int index;
    private SpriteRenderer catSprite;
    private SpriteRenderer numberSprite;
    private GameManager gameManager;
    public Cat brother;
    private Board board;
    public Sprite[] catSprites = new Sprite[2];
    public Sprite[] numberSprites = new Sprite[36];

    void Awake(){
        catSprite = this.transform.Find("catSprite").GetComponent<SpriteRenderer>();
        numberSprite = this.transform.Find("numberSprite").GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        board = GameObject.Find("board").GetComponent<Board>();
    }

    void Start(){
    }

    public void Conquer() {
        Field parent = this.transform.parent.parent.GetComponent<Field>();
        parent.SetAlreadyCollapsed(owner);
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
        owner = index;
        this.catSprite.sprite = this.catSprites[index];
    }

    public void SetIndex(int index){
        this.index = index;
        this.numberSprite.sprite = this.numberSprites[index-1];
        
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
