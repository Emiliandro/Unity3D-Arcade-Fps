using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {
    
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 26);
    }

    void onCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") Physics.IgnoreCollision(gameObject.GetComponent<Collision>().collider, other.gameObject.GetComponent<Collision>().collider, true);
    }

    void Start()
    {
        Invoke("destroyBullet", 30f * Time.deltaTime);
        Invoke("ativarColisao", 5f * Time.deltaTime);
    }

    void destroyBullet()
    {
        Destroy(this.gameObject);
    }

    void ativarColisao() {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
