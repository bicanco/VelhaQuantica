using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatImage : MonoBehaviour
{
    private SpriteRenderer catSprite;
    private SpriteRenderer numberSprite;
    private SpriteRenderer glowSprite;

    // selecionando sprite a aparecer no gato
    public void SetSprite(Sprite cat, Sprite number) {
        catSprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        numberSprite = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
        this.catSprite.sprite = cat;
        this.numberSprite.sprite = number;
    }

    // selecioando brilho a aparecer no gato
    public void SetGlow(Sprite glow) {
        glowSprite = this.transform.GetChild(2).GetComponent<SpriteRenderer>();
        glowSprite.sprite = glow;
        glowSprite.color = Color.yellow;
        glowSprite.gameObject.SetActive(true);
    }
}
