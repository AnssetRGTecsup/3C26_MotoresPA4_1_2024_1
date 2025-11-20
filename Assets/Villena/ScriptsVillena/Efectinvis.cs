using UnityEngine;

public class Efectinvis : MonoBehaviour
{
    [SerializeField] private string nameobject;
    private PlayerController playercontrole;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == nameobject){
           // playercontrole;
        }
    }
}
