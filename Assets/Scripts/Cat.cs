using UnityEngine;

public class Cat: MonoBehaviour
{
    private int index;
    private SpriteRenderer sprite;
    private Cat brother;
    public Sprite[] sprites = new Sprite[2];

    void Awake(){
        this.sprite = this.transform.Find("Sprite").GetComponent<SpriteRenderer>();

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

    public static Cat Instantiate(Cat cat, Transform position, int sprite, int index){
        Cat temp = Instantiate(cat, position, false);
        temp.SetSprite(sprite);
        temp.SetIndex(index);
        return temp;
    }
    
}
