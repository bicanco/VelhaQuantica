using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
	
 
    public Text txt;
    public Text page;
    public Image img;
	public Sprite tutorial01;
	public Sprite tutorial02;
	public Sprite tutorial03;
	public Sprite tutorial04;
	public Sprite tutorial05;
	public Sprite tutorial06;
	public Sprite tutorial07;
	public Sprite tutorial08;
	public Sprite tutorial09;
	public Sprite tutorial10;

 	

    public void NextText()
    {
    	// selecionando a página do tutorial
    	switch (page.text)
    	{
    		case "1/10":
    		txt.text = "Mas os meus gatinhos não são normais, eles são quânticos! Quer dizer, eles respeitam certas regras da física quântica durante o jogo. Quando você jogar, você sempre coloca dois gatinhos quânticos de uma vez, um em cada quadrante.";
    		img.sprite = tutorial02;
    		page.text = "2/10";
    		break;

    		case "2/10":
    		txt.text = "Como eles ainda não são totalmente estáveis, você pode colocar um dos meus fofinhos em quadrado que não esteja vazio, ou seja, mesmo que já tenha outros gatinhos por lá. Isso é o que chamamos de sobreposição quântica!";
    		img.sprite = tutorial03;
    		page.text = "3/10";
    		break;

    		case "3/10":
    		txt.text = "Eu sempre coloco números nas costas dos gatinhos quânticos pra ajudar meus pudinzinhos a saber qual faz parte de cada par. Eles estarão sempre conectados um ao outro e representam possíveis lugares que o gatinho grande poderá estar.";
    		img.sprite = tutorial04;
    		page.text = "4/10";
    		break;

    		case "4/10":
    		txt.text = "Essas conexões são importantes pois elas podem causar o que a gente chama de entrelaçamento cíclico! Isso acontece quando vários quadrantes são conectados por meio de pares de gatinhos, formando um ciclo entre eles.";
    		img.sprite = tutorial05;
    		page.text = "5/10";
    		break;

    		case "5/10":
    		txt.text = "Eu fico um pouco preocupada com meus fofinhos quando isso acontece porque eles ficam muito confusos - então, toda vez que isso acontecer, precisaremos medir a posição dos gatinhos e descobrir onde qual gatinho grande realmente está!";
    		img.sprite = tutorial06;
    		page.text = "6/10";
    		break;

    		case "6/10":
    		txt.text = "O pudinzinho que colocou os gatinhos que formaram o ciclo deixam o outro jogador escolher o que vai acontecer a partir dessa medição. Ele vai escolher qual gatinho quântico que está em destaque realmente está naquele quadrante, clicando nele.";
    		img.sprite = tutorial07;
    		page.text = "7/10";
    		break;

    		case "7/10":
    		txt.fontSize = 21;
    		txt.text = "O gatinho quântico que for clicado vira um gatinho grande e assume todo o quadrante! Agora, já que ele é um gatinho real (e não mais quântico), ele não pode estar em dois lugares ao mesmo tempo. Assim, seu irmão quântico desaparece e o outro fofinho fica grande e assume o quadrante em que ele estava.";
    		img.sprite = tutorial08;
    		page.text = "8/10";
    		break;

    		case "8/10":
    		txt.fontSize = 27;
    		txt.text = "Esse processo segue colapsando os meus fofinhos em todos os quadrantes que faziam parte do ciclo. Onde tem um gatinho grande, não se pode mais colocar gatinhos quânticos.";
    		img.sprite = tutorial09;
    		page.text = "9/10";
    		break;

    		case "9/10":
    		txt.text = "Depois disso, vocês dois continuam colocando gatinhos quânticos até alguém vencer. Divirtam-se";
    		img.sprite = tutorial10;
    		page.text = "10/10";
    		break;


    	}

    	
    }

	public void PreviousText()
    {
    	switch (page.text)
    	{
    		case "10/10":
    		txt.text = "Esse processo segue colapsando os meus fofinhos em todos os quadrantes que faziam parte do ciclo. Onde tem um gatinho grande, não se pode mais colocar gatinhos quânticos.";
            img.sprite = tutorial09;
    		page.text = "9/10";
    		break;

    		case "9/10":
			txt.fontSize = 21;
            txt.text = "O gatinho quântico que for clicado vira um gatinho grande e assume todo o quadrante! Agora, já que ele é um gatinho real (e não mais quântico), ele não pode estar em dois lugares ao mesmo tempo. Assim, seu irmão quântico desaparece e o outro fofinho fica grande e assume o quadrante em que ele estava.";
            img.sprite = tutorial08;
    		page.text = "8/10";
    		break;

    		case "8/10":
    		txt.fontSize = 27;
            txt.text = "O pudinzinho que colocou os gatinhos que formaram o ciclo deixam o outro jogador escolher o que vai acontecer a partir dessa medição. Ele vai escolher qual gatinho quântico que está em destaque realmente está naquele quadrante, clicando nele.";
            img.sprite = tutorial07;
    		page.text = "7/10";
    		break;

    		case "7/10":
    		txt.text = "Eu fico um pouco preocupada com meus fofinhos quando isso acontece porque eles ficam muito confusos - então, toda vez que isso acontecer, precisaremos medir a posição dos gatinhos e descobrir onde qual gatinho grande realmente está!";
            img.sprite = tutorial06;
    		page.text = "6/10";
    		break;

    		case "6/10":
    		txt.text = "Essas conexões são importantes pois elas podem causar o que a gente chama de entrelaçamento cíclico! Isso acontece quando vários quadrantes são conectados por meio de pares de gatinhos, formando um ciclo entre eles.";
            img.sprite = tutorial05;
    		page.text = "5/10";
    		break;

    		case "5/10":
    		txt.text = "Eu sempre coloco números nas costas dos gatinhos quânticos pra ajudar meus pudinzinhos a saber qual faz parte de cada par. Eles estarão sempre conectados um ao outro e representam possíveis lugares que o gatinho grande poderá estar.";
            img.sprite = tutorial04;
    		page.text = "4/10";
    		break;

    		case "4/10":
    		txt.text = "Como eles ainda não são totalmente estáveis, você pode colocar um dos meus fofinhos em quadrado que não esteja vazio, ou seja, mesmo que já tenha outros gatinhos por lá. Isso é o que chamamos de sobreposição quântica!";
            img.sprite = tutorial03;
    		page.text = "3/10";
    		break;

    		case "3/10":
    		txt.text = "Mas os meus gatinhos não são normais, eles são quânticos! Quer dizer, eles respeitam certas regras da física quântica durante o jogo. Quando você jogar, você sempre coloca dois gatinhos quânticos de uma vez, um em cada quadrante.";
            img.sprite = tutorial02;
    		page.text = "2/10";
    		break;

    		case "2/10":
    		txt.text = "Meus pudinzinhos! Vocês vieram aprender a brincar com os meus gatinhos? Vamos começar! Seu objetivo é conseguir colocar três gatinhos grandes da sua cor, formando uma linha horizontal, vertical ou diagonal, como no jogo da velha.";
            img.sprite = tutorial01;
    		page.text = "1/10";
    		break;


    	}

    	
    	
    }    

}