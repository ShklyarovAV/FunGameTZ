using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureAnimalGroup", menuName = "FigureCharacteristic/FigureAnimalGroup")]
public class FigureAnimalGroupData : ScriptableObject
{
    [SerializeField] private List<FigureAnimalData> _figureAnimalDatas;

    public List<FigureAnimalData> FigureAnimalDatas => _figureAnimalDatas;
}
