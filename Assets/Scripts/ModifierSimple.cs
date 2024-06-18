using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierSimple : MonoBehaviour
{
    [SerializeField] private MaterialColorController BaseColorChange;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Interacting");

        if (other.CompareTag("Player"))
        {
            Debug.Log("With Player");

            BaseColorChange.UpdateColorTween();
        }
    }
}
