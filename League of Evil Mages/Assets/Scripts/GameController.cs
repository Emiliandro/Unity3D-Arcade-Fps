using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int tempo_de_jogo = 25;
    public float valorAtual;
    public Text valor;
    
        
    void Start () {
        Time.timeScale = 1;
        tempo_de_jogo = Random.Range(35,55);
        valorAtual = tempo_de_jogo;
    }

    void FixedUpdate () {
        valorAtual -= Time.deltaTime;
        DisplayText();
        if (valorAtual < 0) PararJogo();
    }

    void DisplayText() {
        //text = valorAtual.ToString();
        valor.text = "0" + Mathf.Round(valorAtual).ToString();
    }

    void PararJogo() {
        Time.timeScale = 0;
    }
}
