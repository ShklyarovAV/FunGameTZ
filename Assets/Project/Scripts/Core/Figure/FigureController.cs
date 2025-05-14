using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
    [SerializeField] private FigureSpawner _figureSpawner;

    private List<Figure> _activeFigures = new List<Figure>();

    public FigureSpawner FigureSpawner => _figureSpawner;

    public void AddFigure(Figure figure)
    {
        _activeFigures.Add(figure);
    }

    public void ReleaseFigure(Figure figure)
    {
        _activeFigures.Remove(figure);
    } 

    public void Clear()
    {
        _activeFigures.Clear();
    }
}
