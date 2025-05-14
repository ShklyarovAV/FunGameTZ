using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureGroup", menuName = "FigureCharacteristic/FigureGroup")]
public class FigureGroupData : ScriptableObject
{
    [SerializeField] private List<FigureData> _figureDatas;

    public List<FigureData> FigureDatas => _figureDatas;
}
