using UnityEngine;
using System.Collections;

public class espadas : MonoBehaviour {

    public GameObject espada_um, espada_dois, espada_tres;

    void Start() {
        espada_um.SetActive(true);
        espada_dois.SetActive(false);
        espada_tres.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            espada_um.SetActive(true);
            espada_dois.SetActive(false);
            espada_tres.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            espada_um.SetActive(false);
            espada_dois.SetActive(true);
            espada_tres.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            espada_um.SetActive(false);
            espada_dois.SetActive(false);
            espada_tres.SetActive(true);
        }
    }
}
