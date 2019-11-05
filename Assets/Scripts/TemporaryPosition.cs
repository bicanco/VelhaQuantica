using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPosition : MonoBehaviour
{
    public Sprite[] catSprites = new Sprite[2];
    public Sprite[] numberSprites = new Sprite[36];

    public void SetSprite(int index, int child) {
        transform.GetChild(child).GetChild(0).GetComponent<SpriteRenderer>().sprite = this.catSprites[index];
    }

    public void SetIndex(int index, int child) {
        transform.GetChild(child).GetChild(1).GetComponent<SpriteRenderer>().sprite = this.numberSprites[index-1];
        
    }    
}
