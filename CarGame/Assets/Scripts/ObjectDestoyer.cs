using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestoyer : MonoBehaviour
{
    [SerializeField] AudioClip playerPointsound;
    [SerializeField] [Range(0, 1)] float playerPointsoundVolume = 0.75f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            //Plays PointGain Sound
            AudioSource.PlayClipAtPoint(playerPointsound, Camera.main.transform.position, playerPointsoundVolume);

            collision.GetComponent<Enemy>().Addpoints();
        }

        Destroy(collision.gameObject);

    }



}
