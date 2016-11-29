using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private float life = 1;
    [SerializeField]
    private Image image;

    void Update()
    {
        image.fillAmount = life;
        if (life < 0) {
            if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
        }
    }

    void lifeBarUpdate(float i)
    {
        life -= i;
        if (life > 0.5f) image.color = Color.green;
        if (life < 0.5f) image.color = Color.red;
        if (life < 0) destroyUpdate();
    }

    void destroyUpdate()
    {
        Time.timeScale = 0;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "AutoKill")
        {
            lifeBarUpdate(0.02f);
        }
    }
}
