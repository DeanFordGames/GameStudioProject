using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private Slider healthBar;
    private Text healthText;

    private Animator anim;

    private int health = 100;

    [SerializeField]
    private GameObject deathScreen;

    private void Awake()
    {
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.SetActive(false);
    }

    private void Start()
    {
        anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
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
            anim.SetBool("isDead", true);
            Invoke("death", 1.5f);
        }
    }

    private void death()
    {
        deathScreen.SetActive(true);
        Destroy(gameObject);
    }
}
