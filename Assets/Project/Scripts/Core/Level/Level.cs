using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private FigureController _figureController;
    [SerializeField] private SpotController _spotController;
    
    public FigureController FigureController => _figureController;
    public SpotController SpotController => _spotController;

    public void StartLevel()
    {
        _figureController.FigureSpawner.SpawnFigures();
    }
}
