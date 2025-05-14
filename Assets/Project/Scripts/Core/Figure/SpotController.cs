using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpotController : MonoBehaviour
{
    [SerializeField] private List<Spot> _spots = new List<Spot>();
    [SerializeField] private int _reqSameCount = 3;

    private List<Figure> _flyFigure = new List<Figure>();
    private FigureController _figureController;
    private LevelManager _levelManager;

    public int CountReserveSpot => _spots.FindAll(p => !p.IsEmpty).Count;

    [Inject]
    public void Construct(LevelManager levelManager)
    {
        _figureController = levelManager.Level.FigureController;
        _levelManager = levelManager;
    }

    public bool TryAddFigure(Figure figure)
    {
        int freeId = _spots.FindIndex(p => p.IsEmpty);

        if (freeId == -1)
        {
            return false;
        }

        _spots[freeId].Reserve();
        _figureController.ReleaseFigure(figure);
        _flyFigure.Add(figure);

        figure.SetOrderLayer(1);
        figure.ActiveRB(false);
        figure.Mover.Move(_spots[freeId].transform.position,
                          () => 
                          {
                              AddFigure(figure, freeId);
                              _flyFigure.Remove(figure);
                              ReleaseSame();
                          });

        return true;
    }

    private void AddFigure(Figure figure, int id)
    {
        _spots[id].Push(figure);
        figure.SetOrderLayer(-3);
    }

    private void ReleaseSame()
    {
        List<Spot>  releaseSpots = new List<Spot>(new Spot[_spots.Count]);

        for (int i = 0; i < _spots.Count; i++)
        {
            if (_spots[i].Figure == null)
            {
                continue;
            }

            if (_spots.FindAll(p => _spots[i].Figure.Equals(p.Figure)).Count >= _reqSameCount)
            {
                releaseSpots[i] = _spots[i];
            }
        }

        foreach (var spot in releaseSpots)
        {
            if (spot != null)
            {
                spot.Release();
            }
        }

        if (_spots.FindIndex(p => !p.IsFigureInSpot) == -1)
        {
            _levelManager.Level.LoseLevel();
        }

        if (_spots.FindIndex(p => p.IsFigureInSpot) == -1 && _levelManager.Level.FigureController.FiguresCount == 0)
        {
            _levelManager.Level.WinLevel();
        }
    }

    public void Clear()
    {
        foreach (var spot in _spots)
        {
            spot.Clear();
        }

        foreach (var flyFigure in _flyFigure)
        {
            if (flyFigure != null)
            {
                Destroy(flyFigure.gameObject);
            }
        }

        _flyFigure.Clear();
    }
}
