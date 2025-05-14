using UnityEngine;

[CreateAssetMenu(fileName = "FigureColor", menuName = "FigureCharacteristic/FigureColor")]
public class FigureColorData : ScriptableObject
{
    [SerializeField] private ColorType _colorType;
    [SerializeField] private Color _color;

    public ColorType ColorType => _colorType;
    public Color Color => _color;
}
