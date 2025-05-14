using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureColorGroup", menuName = "FigureCharacteristic/FigureColorGroup")]
public class FigureColorGroupData : ScriptableObject
{
    [SerializeField] private List<FigureColorData> _figureColorDatas;

    public List<FigureColorData> FigureColorDatas => _figureColorDatas;
}
