using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ParedMovimiento : MonoBehaviour
{
    float tiempo = 5f;
    public float moveDuration = 2f;
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public Vector3 targetScale;
    public Vector3 initialPosition;

    void Start()
    {

        initialPosition = transform.position;

        transform.DOMove(targetPosition, moveDuration);
        
        transform.DORotate(targetRotation, moveDuration);

        transform.DOScale(targetScale, moveDuration);
       
    }
    private void Update()
    {
        if (transform.position == targetPosition)
        {
            transform.DOMove(initialPosition, moveDuration);

          
        }else if (transform.position == initialPosition)
        {
            
            transform.DOMove(targetPosition, moveDuration);
        
        
        }
    }

}
