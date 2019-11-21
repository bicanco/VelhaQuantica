using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat: MonoBehaviour
{
    private int owner;
    private CatImage catImage;
    private Field parent;
    public Cat brother;
    private Board board;
    public delegate void genericFunction();
    private static List<genericFunction> showLater = new List<genericFunction>();
    [SerializeField()]
    private float delayCollapse = 0;
    private static float delayCollapseForSeconds;
    public Sprite[] catSprites = new Sprite[2];
    public Sprite[] numberSprites = new Sprite[36];

    void Awake(){
        delayCollapseForSeconds = delayCollapse;
        parent = this.transform.parent.parent.GetComponent<Field>();
        catImage = this.transform.Find("catImage").GetComponent<CatImage>();
        board = GameObject.Find("board").GetComponent<Board>();
        catImage.gameObject.SetActive(false);
    }

    private void AddToShowLater(genericFunction toDestroy){
        showLater.Add(toDestroy);
    }

    public static IEnumerator ExecuteQueuedShowLater(genericFunction onEnd){
        foreach(genericFunction showCatCollapse in Cat.showLater) {
            yield return new WaitForSeconds(delayCollapseForSeconds);
            showCatCollapse();
        }
        Cat.showLater = new List<genericFunction>();
        onEnd();
    }

    private void showCollapse(){
        // Acionando gato que deve ocupar o campo e desativando gatos pequenos
        catImage.gameObject.SetActive(true);
        parent.SetAlreadyCollapsed(owner);
        parent.DeactivateTP();
    }

    // Causando colapso do ciclo
    public void Conquer() {
        AddToShowLater(showCollapse);

        // Propagando o colapso dos gatos conectados
        Transform cats = parent.transform.GetChild(0);
        for(int i = 0; i < cats.childCount; i ++){
            Cat cat = cats.GetChild(i).GetComponent<Cat>();
            if(cat.gameObject != this.gameObject) {
                if(cat.brother != null){
                    cat.brother.RemoveBrother();
                    cat.brother.Conquer();
                }
                Object.Destroy(cat.gameObject);
            }
        }
    }

    // Selecionando o sprite que deve aparecer no gato
    private void SetSprite(int cat, int number, GameObject minicat) {
        owner = cat;
        Sprite catSprite = catSprites[cat];
        Sprite numberSprite = numberSprites[number-1];
        catImage.SetSprite(catSprite, numberSprite);
        minicat.GetComponent<CatImage>().SetSprite(catSprite, numberSprite);
    }

    // Conectando dois gatos
    public static void SetBrothers(Cat cat1, Cat cat2) {
        cat1.brother = cat2;
        cat2.brother = cat1;
    }

    // Desconectando dois gatos
    public void RemoveBrother() {
        if(brother != null){
            board.Disconnect(
                this.gameObject.transform.parent.parent.GetComponent<Field>().index,
                brother.gameObject.transform.parent.parent.GetComponent<Field>().index
            );
        }
        brother = null;
    }

    // Sobrecarga do método de instanciação de um gato para adicionar os sprites necessários
    public static Cat Instantiate(Cat cat, Transform position, int sprite, int index, GameObject miniCat){
        Cat temp = Instantiate(cat, position, false);
        temp.SetSprite(sprite, index, miniCat);
        return temp;
    }

    // Retornando o gato pequeno
    public CatImage GetMiniCat() {
        return parent.GetComponent<Field>().GetCurrent().GetComponent<CatImage>();
    }
}
