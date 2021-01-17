using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    public Text healthText;
    public Player player;

    public void Start()
    {
        healthText = GetComponent<Text>();

        player = FindObjectOfType<Player>();
    }

    public void Update()
    {
        healthText.text = player.Gethealth().ToString();

    }

}
