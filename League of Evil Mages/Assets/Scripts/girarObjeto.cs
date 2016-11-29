using UnityEngine;
using System.Collections;

public class girarObjeto : MonoBehaviour
    {

    void FixedUpdate(){
        transform.Rotate(new Vector3(0f, 60f, 0f) * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
