using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemieController : MonoBehaviour {

    private float life = 1;
    [SerializeField]private Image image;

    void Update () {
        image.fillAmount = life;
	}

    void lifeBarUpdate(float i) {
        life -= i;

        if (life > 0.5f) image.color = Color.green;
        if (life < 0.5f) image.color = Color.red;
        if (life < 0) destroyUpdate();
    }

    void destroyUpdate() {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet") {
            lifeBarUpdate(0.4f);
        }
    }
}
