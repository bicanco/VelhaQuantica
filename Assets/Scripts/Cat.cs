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
    }

    void Start(){
        board = GameObject.Find("board").GetComponent<Board>();
    }

    public void Conquer() {
        foreach (Cat cat in this.transform.parent.GetComponentsInChildren<Cat>())
        {
            if(cat.gameObject != this.gameObject) {
                Object.Destroy(cat.gameObject);
                try{
                    cat.brother.Conquer();
                } catch(System.Exception e){
                    gameManager.EndCollapse();
                    continue;
                }
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

    public static void RemoveBrothers(Cat cat1, Cat cat2) {
        cat1.brother = null;
        cat2.brother = null;
    }
    public static Cat Instantiate(Cat cat, Transform position, int sprite, int index){
        Cat temp = Instantiate(cat, position, false);
        temp.SetSprite(sprite);
        temp.SetIndex(index);
        return temp;
    }
    
}
