using UnityEngine;
using System.Collections;

public class girarObjeto : MonoBehaviour
    {

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 60f, 0f) * Time.deltaTime);

    }
}
