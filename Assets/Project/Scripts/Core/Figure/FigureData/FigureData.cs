using UnityEngine;

[CreateAssetMenu(fileName = "Figure", menuName = "FigureCharacteristic/Figure")]
public class FigureData : ScriptableObject
{
    [SerializeField] private Figure _figure;

    public Figure Figure => _figure;
    public FrameType FrameType => _figure.FrameType;
}
