using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour {
    public string tagged;
	// Use this for initialization
	void EndGame () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == tagged) {
            Application.LoadLevel(Application.loadedLevel);
            
        }
    }
}
