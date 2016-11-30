using UnityEngine;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour {

    public static CoinManager coinManager;

    public void Awake(){
        if (coinManager == null)
            coinManager = this;
        else
            Destroy(this.gameObject);
    }

    public List<girarObjeto> coins = new List<girarObjeto>();

	// Update is called once per frame
	void Update () {
        if (coins.Count <= 0)
            return;

        foreach(girarObjeto g in coins){
            g.RotateObject();
        }
	}

    public void DestroyCoinInstance(girarObjeto coin){
        coins.Remove(coin);
    }

}
