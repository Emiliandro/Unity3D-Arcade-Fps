using UnityEngine;
using System.Collections;

public class EnemiesCollider : MonoBehaviour {

    [Header("Indique a velocidade do vermelho")]
    public float tempo = 2f;
    private SpriteRenderer sprite;

    // Use this for initialization
    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Bullet")
        {
            GetComponent<AudioSource>().Play();
            startRed();
        }
    }

    void startRed()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        goRed();
    }

    void goRed()
    {
        sprite.color = Color.red;
        StartCoroutine("anulaRed");

    }

    IEnumerator anulaRed()
    {
        while (sprite.color.g < 0.99f && sprite.color.b < 0.99f)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g + (Time.deltaTime / tempo), sprite.color.b + (Time.deltaTime / tempo), sprite.color.a);
            yield return new WaitForSeconds(Time.deltaTime / 2);
        }
    }

}