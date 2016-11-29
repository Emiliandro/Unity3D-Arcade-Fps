using UnityEngine;
using System.Collections;

public class KeysController : MonoBehaviour {


	// Update is called once per frame
	void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
	}
}
