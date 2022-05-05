using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private int maxHealth = 30;
    private int health = 30;
    private int points = 50;

    [SerializeField]
    private GameObject healthBar;
    private GameObject healtBarInstance;

    public void getHit(int damage)
    {
        health -= damage;
        if (health <= 0)
            dropItem();
        if(healtBarInstance != null)
        {
            healtBarInstance.transform.GetChild(0).gameObject.GetComponent<Slider>().value = health;
        }
    }

    private void dropItem()
    {
        ScoreSystem score = GameObject.Find("Score").GetComponent<ScoreSystem>();
        score.changeScore(points);
        Destroy(healtBarInstance);
    }

    private void Update()
    {
        if (healtBarInstance == null)
        {
            if (health != maxHealth)
            {
                healtBarInstance = Instantiate(healthBar, gameObject.transform.GetChild(1).position, Quaternion.Euler(0, this.transform.rotation.y, 0));
                healtBarInstance.transform.GetChild(0).gameObject.GetComponent<Slider>().maxValue = maxHealth;
                healtBarInstance.transform.GetChild(0).gameObject.GetComponent<Slider>().value = health;
            }
        }

        if(healtBarInstance != null)
        {
            healtBarInstance.transform.position = gameObject.transform.GetChild(1).position;
            healtBarInstance.transform.rotation = Quaternion.Euler(0, this.transform.rotation.y, 0);
        }
    }

    public int getHealth()
    {
        return health;
    }
}
