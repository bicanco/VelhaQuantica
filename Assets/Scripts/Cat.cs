using UnityEngine;

public class Cat: MonoBehaviour
{
    private int index;
    private SpriteRenderer sprite;
    private GameManager gameManager;
    public Cat brother;
    private Board board;
    public Sprite[] sprites = new Sprite[2];


    void Awake(){
        sprite = this.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        board = GameObject.Find("board").GetComponent<Board>();
    }

    void Start(){
    }

    public void Conquer() {
        Field parent = this.transform.parent.parent.GetComponent<Field>();
        parent.SetAlreadyCollapsed();
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
        this.sprite.sprite = this.sprites[index];
    }

    public void SetIndex(int index){
        this.index = index;
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
