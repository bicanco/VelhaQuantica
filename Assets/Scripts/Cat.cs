using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat: MonoBehaviour
{
    private int index;
    private SpriteRenderer sprite;
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

}
