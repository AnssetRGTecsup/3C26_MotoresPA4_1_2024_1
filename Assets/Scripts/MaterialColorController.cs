using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Material Color Change", menuName = "Scritpable Objects/Material Controller/Color")]
public class MaterialColorController : ScriptableObject
{
    [SerializeField] private Material CurrentMaterial;
    [SerializeField] private Color ColorMaterial;
    [SerializeField] private string ColorProperty;

    [SerializeField] private TweenProperties TweenData;
    [SerializeField] private ColorValues TweenValues;

    public void UpdateColorTween()
    {
        if (TweenData.UseAnimationCurve)
        {
            CurrentMaterial.DOColor(ColorMaterial, ColorProperty, TweenData.Duration).SetEase(TweenData.AnimationCurve);
        }
        else
        {
            CurrentMaterial.DOColor(ColorMaterial, ColorProperty, TweenData.Duration).SetEase(TweenData.Ease);
        }
    }

    public void UpdateColorTween(MeshRenderer mesh)
    {
        MaterialPropertyBlock material = new();

        DOVirtual.Color(TweenValues.StartValue, TweenValues.EndValue, TweenData.Duration, (Color value) =>
        {
            material.SetColor(ColorProperty, value);
            mesh.SetPropertyBlock(material);
        });
    }
}


[System.Serializable]
public struct TweenProperties
{
    [Header("Tween Properties")]
    public float Duration;
    public Ease Ease;
    public bool UseAnimationCurve;
    public AnimationCurve AnimationCurve;
}

[System.Serializable]
public struct ColorValues
{
    [ColorUsage(showAlpha: true, hdr: true)] public Color StartValue;
    [ColorUsage(showAlpha: true, hdr: true)] public Color EndValue;
}
