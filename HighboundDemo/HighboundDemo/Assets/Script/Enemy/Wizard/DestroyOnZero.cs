using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnZero : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private Slider health;

    private void Update()
    {
        if (health.value <= 0)
            Destroy(parent);
    }
}
