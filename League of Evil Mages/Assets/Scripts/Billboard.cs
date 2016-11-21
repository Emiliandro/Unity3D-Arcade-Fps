using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    private Transform tf;
    private Camera cameraMain;

    private void Awake(){
        tf = gameObject.transform;
        cameraMain = Camera.main;
    }


    
	// Update is called once per frame
	void LateUpdate() {
        Vector3 cameraPos = cameraMain.transform.position;
        cameraPos.y = tf.position.y;
        tf.LookAt(cameraPos);
	
	}
}
