using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorVictory : MonoBehaviour
{
    [SerializeField]
    private GameObject vicScreen;
    private GameObject vicScreenInstance;

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.name == "Player")
        {
            if(vicScreenInstance == null)
                vicScreenInstance =  Instantiate(vicScreen, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }  
    }
}
