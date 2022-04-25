using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private Slider healthBar;
    private Text healthText;

    private int health = 100;

    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        healthBar.maxValue = health;
        healthBar.minValue = 0;
        healthBar.value = health;
        healthText = healthBar.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();
        healthText.text = health + " / 100";
    }

    public void hitPlayer(int damage)
    {
        health -= damage;
        healthBar.value = health;
        healthText.text = health + " / 100";
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
