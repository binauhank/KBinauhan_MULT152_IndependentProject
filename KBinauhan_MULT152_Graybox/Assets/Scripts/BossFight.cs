using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 direction = Vector3.left;

    public Health healthScript;
    public GameObject[] upgradeDrop;

    void Start()
    {
        for (int i = 0; i < upgradeDrop.Length; i++)
        {
            upgradeDrop[i].SetActive(false);
        }
    }
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x <= -4)
        {
            direction = Vector3.right;
        }
        else if (transform.position.x >= 4)
        {
            direction = Vector3.left;
        }

        if (healthScript.enemyHealth <= 0)
        {
            for (int i = 0; i < upgradeDrop.Length; i++)
            {
                upgradeDrop[i].SetActive(true);
            }
        }
    }
}