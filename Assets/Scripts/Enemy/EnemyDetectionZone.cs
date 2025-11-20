using UnityEngine;

public class EnemyDetectionZone : MonoBehaviour
{
    private bool playerInColliderZone = false;
    public bool PlayerInColliderZone => playerInColliderZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInColliderZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInColliderZone = false;
        }
    }
}
