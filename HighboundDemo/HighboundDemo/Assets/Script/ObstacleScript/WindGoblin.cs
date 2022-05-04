using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGoblin : MonoBehaviour
{
    [SerializeField]
    private GameObject wind;

    private Transform shootPoint;
    private float shootTimer;

    private Quaternion rot;

    private void Start()
    {
        rot = Quaternion.Euler(90, 0, 0);
        shootPoint = gameObject.transform.GetChild(0);
        shootTimer = Random.Range(0.5f, 2.0f);
    }

    private void Update()
    {
        if(shootTimer <= 0)
        {
            shootTimer = Random.Range(0.5f,2.0f);
            Instantiate(wind, shootPoint.position, this.transform.rotation * rot);
        }else
        {
            shootTimer -= Time.deltaTime;
        }
    }
}
