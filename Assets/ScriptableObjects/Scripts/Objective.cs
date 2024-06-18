using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Objective", menuName = "Scriptable Objects/Objectives")]
public class Objective : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }
    [SerializeField] private string objectiveText;
    public string ObjectiveText
    {
        get
        {
            return objectiveText;
        }
    }
    public void SetData()
    {
        prefab.GetComponentInChildren<TMP_Text>().text = objectiveText;
    }
}
