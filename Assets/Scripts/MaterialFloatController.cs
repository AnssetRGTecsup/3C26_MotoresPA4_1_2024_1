using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Material Float Change", menuName = "Scritpable Objects/Material Controller/Float")]
public class MaterialFloatController : ScriptableObject
{
    [SerializeField] private Material CurrentMaterial;
    [SerializeField] private float FloatMaterial;
    [SerializeField] private string FloatProperty;

    [SerializeField] private TweenProperties TweenData;
    [SerializeField] private FloatValues TweenValues;

    public void UpdateFloatTween()
    {
        if (TweenData.UseAnimationCurve)
        {
            CurrentMaterial.DOFloat(FloatMaterial, FloatProperty, TweenData.Duration).SetEase(TweenData.AnimationCurve);
        }
        else
        {
            CurrentMaterial.DOFloat(FloatMaterial, FloatProperty, TweenData.Duration).SetEase(TweenData.Ease);
        }
    }

    public void UpdateFloatTween(MeshRenderer mesh)
    {
        MaterialPropertyBlock material = new();

        DOVirtual.Float(TweenValues.StartValue, TweenValues.EndValue, TweenData.Duration, (float value) =>
        {
            material.SetFloat(FloatProperty, value);
            mesh.SetPropertyBlock(material);
        });
    }
}

[System.Serializable]
public struct FloatValues
{
    public float StartValue;
    public float EndValue;
}
