using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
	
 
    public Text txt;
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
    	
    	if (txt.text == "Meus pudinzinhos! Vocês vieram aprender a brincar com os meus gatinhos? Vamos começar! Seu objetivo é conseguir colocar três gatinhos grandes da sua cor, formando uma linha horizontal, vertical ou diagonal, como no jogo da velha.")
    	{
    		txt.text = "Mas os meus gatinhos não são normais, eles são quânticos! Quer dizer, eles respeitam certas regras da física quântica durante o jogo. Quando você jogar, você sempre coloca dois gatinhos quânticos de uma vez, um em cada quadrante.";
    		img.sprite = tutorial02;
    	}

    	else if (txt.text == "Mas os meus gatinhos não são normais, eles são quânticos! Quer dizer, eles respeitam certas regras da física quântica durante o jogo. Quando você jogar, você sempre coloca dois gatinhos quânticos de uma vez, um em cada quadrante.")
    	{
    		txt.text = "Como eles ainda não são totalmente estáveis, você pode colocar um dos meus fofinhos em quadrado que não esteja vazio, ou seja, mesmo que já tenha outros gatinhos por lá. Isso é o que chamamos de sobreposição quântica!";
    		img.sprite = tutorial03;
    	}

    	else if (txt.text == "Como eles ainda não são totalmente estáveis, você pode colocar um dos meus fofinhos em quadrado que não esteja vazio, ou seja, mesmo que já tenha outros gatinhos por lá. Isso é o que chamamos de sobreposição quântica!")
    	{
    		txt.text = "Eu sempre coloco números nas costas dos gatinhos quânticos pra ajudar meus pudinzinhos a saber qual faz parte de cada par. Eles estarão sempre conectados um ao outro e representam possíveis lugares que o gatinho grande poderá estar.";
    		img.sprite = tutorial04;
    	}

    	else if (txt.text == "Eu sempre coloco números nas costas dos gatinhos quânticos pra ajudar meus pudinzinhos a saber qual faz parte de cada par. Eles estarão sempre conectados um ao outro e representam possíveis lugares que o gatinho grande poderá estar.")
    	{
    		txt.text = "Essas conexões são importantes pois elas podem causar o que a gente chama de entrelaçamento cíclico! Isso acontece quando vários quadrantes são conectados por meio de pares de gatinhos, formando um ciclo entre eles.";
    		img.sprite = tutorial05;
    	}

    	else if (txt.text == "Essas conexões são importantes pois elas podem causar o que a gente chama de entrelaçamento cíclico! Isso acontece quando vários quadrantes são conectados por meio de pares de gatinhos, formando um ciclo entre eles.")
    	{
    		txt.text = "Eu fico um pouco preocupada com meus fofinhos quando isso acontece porque eles ficam muito confusos - então, toda vez que isso acontecer, precisaremos medir a posição dos gatinhos e descobrir onde qual gatinho grande realmente está!";
    		img.sprite = tutorial06;
    	}

    	else if (txt.text == "Eu fico um pouco preocupada com meus fofinhos quando isso acontece porque eles ficam muito confusos - então, toda vez que isso acontecer, precisaremos medir a posição dos gatinhos e descobrir onde qual gatinho grande realmente está!")
    	{
    		txt.text = "O pudinzinho que colocou os gatinhos que formaram o ciclo deixam o outro jogador escolher o que vai acontecer a partir dessa medição. Ele vai escolher qual gatinho quântico que está em destaque realmente está naquele quadrante, clicando nele.";
    		img.sprite = tutorial07;
    	}

    	else if (txt.text == "O pudinzinho que colocou os gatinhos que formaram o ciclo deixam o outro jogador escolher o que vai acontecer a partir dessa medição. Ele vai escolher qual gatinho quântico que está em destaque realmente está naquele quadrante, clicando nele.")
    	{
    		txt.fontSize = 24;
    		txt.text = "O gatinho quântico que for clicado vira um gatinho grande e assume todo o quadrante! Agora, já que ele é um gatinho real (e não mais quântico), ele não pode estar em dois lugares ao mesmo tempo. Assim, seu irmão quântico desaparece e o outro fofinho fica grande e assume o quadrante em que ele estava.";
    		img.sprite = tutorial08;
    	}

    	else if (txt.text == "O gatinho quântico que for clicado vira um gatinho grande e assume todo o quadrante! Agora, já que ele é um gatinho real (e não mais quântico), ele não pode estar em dois lugares ao mesmo tempo. Assim, seu irmão quântico desaparece e o outro fofinho fica grande e assume o quadrante em que ele estava.")
    	{
    		txt.fontSize = 27;
    		txt.text = "Esse processo segue colapsando os meus fofinhos em todos os quadrantes que faziam parte do ciclo. Onde tem um gatinho grande, não se pode mais colocar gatinhos quânticos.";
    		img.sprite = tutorial09;
    	}
    	
    	else if (txt.text == "Esse processo segue colapsando os meus fofinhos em todos os quadrantes que faziam parte do ciclo. Onde tem um gatinho grande, não se pode mais colocar gatinhos quânticos.")
    	{
    		txt.text = "Depois disso, vocês dois continuam colocando gatinhos quânticos até alguém vencer. Divirtam-se";
    		img.sprite = tutorial10;
    	};
    }

	public void PreviousText()
    {
    	
    	if (txt.text == "Depois disso, vocês dois continuam colocando gatinhos quânticos até alguém vencer. Divirtam-se")
    	{
    		txt.text = "Esse processo segue colapsando os meus fofinhos em todos os quadrantes que faziam parte do ciclo. Onde tem um gatinho grande, não se pode mais colocar gatinhos quânticos.";
    		img.sprite = tutorial09;
    	}

    	else if (txt.text == "Esse processo segue colapsando os meus fofinhos em todos os quadrantes que faziam parte do ciclo. Onde tem um gatinho grande, não se pode mais colocar gatinhos quânticos.")
    	{
    		txt.fontSize = 24;
    		txt.text = "O gatinho quântico que for clicado vira um gatinho grande e assume todo o quadrante! Agora, já que ele é um gatinho real (e não mais quântico), ele não pode estar em dois lugares ao mesmo tempo. Assim, seu irmão quântico desaparece e o outro fofinho fica grande e assume o quadrante em que ele estava.";
    		img.sprite = tutorial08;
    	}

    	else if (txt.text == "O gatinho quântico que for clicado vira um gatinho grande e assume todo o quadrante! Agora, já que ele é um gatinho real (e não mais quântico), ele não pode estar em dois lugares ao mesmo tempo. Assim, seu irmão quântico desaparece e o outro fofinho fica grande e assume o quadrante em que ele estava.")
    	{
    		txt.fontSize = 27;
    		txt.text = "O pudinzinho que colocou os gatinhos que formaram o ciclo deixam o outro jogador escolher o que vai acontecer a partir dessa medição. Ele vai escolher qual gatinho quântico que está em destaque realmente está naquele quadrante, clicando nele.";
    		img.sprite = tutorial07;
    	}

    	else if (txt.text == "O pudinzinho que colocou os gatinhos que formaram o ciclo deixam o outro jogador escolher o que vai acontecer a partir dessa medição. Ele vai escolher qual gatinho quântico que está em destaque realmente está naquele quadrante, clicando nele.")
    	{
    		txt.text = "Eu fico um pouco preocupada com meus fofinhos quando isso acontece porque eles ficam muito confusos - então, toda vez que isso acontecer, precisaremos medir a posição dos gatinhos e descobrir onde qual gatinho grande realmente está!";
    		img.sprite = tutorial06;
    	}

    	else if (txt.text == "Eu fico um pouco preocupada com meus fofinhos quando isso acontece porque eles ficam muito confusos - então, toda vez que isso acontecer, precisaremos medir a posição dos gatinhos e descobrir onde qual gatinho grande realmente está!")
    	{
    		txt.text = "Essas conexões são importantes pois elas podem causar o que a gente chama de entrelaçamento cíclico! Isso acontece quando vários quadrantes são conectados por meio de pares de gatinhos, formando um ciclo entre eles.";
    		img.sprite = tutorial05;
    	}

    	else if (txt.text == "Essas conexões são importantes pois elas podem causar o que a gente chama de entrelaçamento cíclico! Isso acontece quando vários quadrantes são conectados por meio de pares de gatinhos, formando um ciclo entre eles.")
    	{
    		txt.text = "Eu sempre coloco números nas costas dos gatinhos quânticos pra ajudar meus pudinzinhos a saber qual faz parte de cada par. Eles estarão sempre conectados um ao outro e representam possíveis lugares que o gatinho grande poderá estar.";
    		img.sprite = tutorial04;
    	}

    	else if (txt.text == "Eu sempre coloco números nas costas dos gatinhos quânticos pra ajudar meus pudinzinhos a saber qual faz parte de cada par. Eles estarão sempre conectados um ao outro e representam possíveis lugares que o gatinho grande poderá estar.")
    	{
    		txt.text = "Como eles ainda não são totalmente estáveis, você pode colocar um dos meus fofinhos em quadrado que não esteja vazio, ou seja, mesmo que já tenha outros gatinhos por lá. Isso é o que chamamos de sobreposição quântica!";
    		img.sprite = tutorial03;
    	}

    	else if (txt.text == "Como eles ainda não são totalmente estáveis, você pode colocar um dos meus fofinhos em quadrado que não esteja vazio, ou seja, mesmo que já tenha outros gatinhos por lá. Isso é o que chamamos de sobreposição quântica!")
    	{
    		txt.text = "Mas os meus gatinhos não são normais, eles são quânticos! Quer dizer, eles respeitam certas regras da física quântica durante o jogo. Quando você jogar, você sempre coloca dois gatinhos quânticos de uma vez, um em cada quadrante.";
    		img.sprite = tutorial02;
    	}
    	
    	else if (txt.text == "Mas os meus gatinhos não são normais, eles são quânticos! Quer dizer, eles respeitam certas regras da física quântica durante o jogo. Quando você jogar, você sempre coloca dois gatinhos quânticos de uma vez, um em cada quadrante.")
    	{
    		txt.text = "Meus pudinzinhos! Vocês vieram aprender a brincar com os meus gatinhos? Vamos começar! Seu objetivo é conseguir colocar três gatinhos grandes da sua cor, formando uma linha horizontal, vertical ou diagonal, como no jogo da velha.";
    		img.sprite = tutorial01;
    	};
    	
    }    

}