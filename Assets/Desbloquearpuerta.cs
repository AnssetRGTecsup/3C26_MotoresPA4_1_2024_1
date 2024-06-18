using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desbloquearpuerta : MonoBehaviour
{
    public GameObject puerta;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(puerta);
            Destroy(this.gameObject);
        }
    }

}
