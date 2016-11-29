using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public GameObject projetil;

	void FixedUpdate() {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(projetil, transform.position, transform.rotation);
        }
	}
}
