using UnityEngine;
using System.Collections;

public class vinhetas : MonoBehaviour
{
    public SpriteRenderer imagem_um, imagem_dois;
    public int time;
    private SpriteRenderer sprite;
    public string scene = "Prototype";

    void Start()
    {
        imagem_um.color = Color.clear;
        imagem_dois.color = Color.clear;
        Invoke("umImagem", time * 0);
        Invoke("doisImagem", time * 3);
    }
    void umImagem() {
        imagem_dois.color = Color.clear;
        sprite = imagem_um;
        StartCoroutine("FadeIn");
        Invoke("StartFadeOut", time * 2);
    }
    void doisImagem() {
        imagem_um.color = Color.clear;
        sprite = imagem_dois;
        StartCoroutine("FadeIn");
        Invoke("StartFadeOut", time * 2);
        Invoke("GoScene", time * 3);
    }

    IEnumerator FadeIn()
    {
        while (sprite.color.a < 0.99f)
        {
            sprite.color = new Color(1f, 1f, 1f, sprite.color.a + (Time.deltaTime / 2));
            yield return new WaitForSeconds(Time.deltaTime / 2);
        }

    }

    IEnumerator FadeOut()
    {
        while (sprite.color.a > 0.01f)
        {
            sprite.color = new Color(1f, 1f, 1f, sprite.color.a - (Time.deltaTime / 2));
            yield return new WaitForSeconds(Time.deltaTime / 2);
        }
    }

    void StartFadeOut() {
        StartCoroutine("FadeOut");
    }

    void GoScene()
    {
        Application.LoadLevel(scene);
    }
}
