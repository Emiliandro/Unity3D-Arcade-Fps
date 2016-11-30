using UnityEngine;
using System.Collections;

public class girarObjeto : MonoBehaviour
    {

    private void Awake(){
        CoinManager.coinManager.coins.Add(this);
    }


    public void RotateObject(){
        transform.Rotate(new Vector3(0f, 60f, 0f) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            CoinManager.coinManager.DestroyCoinInstance(this);
            Destroy(this.gameObject);
        }
    }
}
