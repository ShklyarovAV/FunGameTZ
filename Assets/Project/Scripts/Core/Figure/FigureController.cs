using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
    [SerializeField] private FigureSpawner _figureSpawner;

    private List<Figure> _activeFigures = new List<Figure>();

    public FigureSpawner FigureSpawner => _figureSpawner;
    public int FiguresCount => _activeFigures.Count;
    public List<Figure> Figures => _activeFigures;

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
        foreach (var figure in _activeFigures)
        {
            if (figure != null)
            {
                Destroy(figure.gameObject);
            }
        }

        _activeFigures.Clear();
    }
}
