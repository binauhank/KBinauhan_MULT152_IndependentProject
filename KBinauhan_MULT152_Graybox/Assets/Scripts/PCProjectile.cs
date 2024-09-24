using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCProjectile : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.3f);
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Breakable")
        {
            Destroy(col.gameObject);
        }
    }
}
