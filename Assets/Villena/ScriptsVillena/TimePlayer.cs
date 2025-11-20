using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimePlayer : MonoBehaviour
{
    [SerializeField] private float timescale;
    [SerializeField] private float TimeLimit;
    [SerializeField] private string namescene;
    void Start()
    {

    }

    void Update()
    {
        timescale = Time.deltaTime + timescale;
        if (timescale >= TimeLimit)
        {
            SceneManager.LoadScene(namescene);
        }
    }
    public void ChangeScene(string namescenegame) {
        SceneManager.LoadScene(namescenegame);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy") {
            SceneManager.LoadScene(namescene);
        }
    }
}
