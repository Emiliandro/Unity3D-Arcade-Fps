using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {
    
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 30);
    }

    void onCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") Physics.IgnoreCollision(gameObject.GetComponent<Collision>().collider, other.gameObject.GetComponent<Collision>().collider, true);
    }

    void Start()
    {
        Invoke("destroyBullet", 1f);
        Invoke("ativarColisao", 0.2f);
    }

    void destroyBullet()
    {
        Destroy(this.gameObject);
    }

    void ativarColisao() {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
