using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ObjectivesController : MonoBehaviour
{
    [SerializeField] private RectTransform[] positions;
    [SerializeField] private Objective[] objetivos;
    private void Start()
    {
        for(int i = 0; i < positions.Length; ++i)
        {
            objetivos[i].SetData();
            GameObject tmp = Instantiate(objetivos[i].Prefab, positions[i]);
        }
    }
    public void CompleteObjective(int index)
    {
        positions[index].gameObject.SetActive(false);
    }
}
