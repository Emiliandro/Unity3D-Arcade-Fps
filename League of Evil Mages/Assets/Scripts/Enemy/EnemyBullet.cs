using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

    public float velocity;

    void Start(){
        Invoke("destroyBullet", 60f * Time.deltaTime);
        Invoke("ativarColisao", 5f * Time.deltaTime);
    }

    void destroyBullet()
    {
        Destroy(this.gameObject);
    }

    void ativarColisao()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    void Update(){
        gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * velocity);
    }

}
