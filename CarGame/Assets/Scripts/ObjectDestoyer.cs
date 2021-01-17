using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestoyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().Die();
        }

        Destroy(collision.gameObject);

    }



}
