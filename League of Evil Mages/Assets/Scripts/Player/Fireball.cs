using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public GameObject projetil, cajado;

	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(projetil, transform.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire2")) {
            cajado.gameObject.SetActive(false);
        }
	}
}
