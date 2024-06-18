using UnityEngine;
public class GreenCubeController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(door);
            Destroy(this.gameObject);
        }
    }
}
