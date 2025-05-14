using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SpotController : MonoBehaviour
{
    [SerializeField] private List<Spot> _spots = new List<Spot>();
    [SerializeField] private int _reqSameCount = 3;

    private FigureController _figureController;

    [Inject]
    public void Construct(LevelManager levelManager)
    {
        _figureController = levelManager.Level.FigureController;
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

        figure.ActiveRB(false);
        figure.Mover.Move(_spots[freeId].transform.position,
                          () => 
                          {
                              AddFigure(figure, freeId);
                              ReleaseSame();
                          });

        return true;
    }

    private void AddFigure(Figure figure, int id)
    {
        _spots[id].Push(figure);
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
    }
}
