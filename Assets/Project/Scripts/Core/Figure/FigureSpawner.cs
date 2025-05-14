using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FigureSpawner : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private FigureGroupData _figureGroupData;
    [SerializeField] private FigureAnimalGroupData _animalGroupData;
    [SerializeField] private FigureColorGroupData _colorGroupData;

    [Space(10)]
    [Header("Spawn settings")]
    [SerializeField] private int _countSpawnGroup = 20;
    [SerializeField] private int _countSameFigure = 3;
    [SerializeField] List<Transform>  _spawnPoints;
    [SerializeField] private float _figureSize = 1.2f;

    private FigureController _figureController;
    private LevelManager _levelManager;

    [Inject]
    public void Construct(LevelManager levelManager)
    {
        _figureController = levelManager.Level.FigureController;
        _levelManager = levelManager;
    }

    public void SpawnFigures(int countSpawnGroup = -1)
    {
        if (countSpawnGroup == -1)
        {
            countSpawnGroup = _countSpawnGroup;
        }

        List <SpawnFigureData> spawnFigureDatas = GenerateFigureDatas(countSpawnGroup);
        List<Vector3> spawnPoints = GenerateSpawnPoints(spawnFigureDatas.Count);

        for (int i = 0; i < spawnFigureDatas.Count; i++)
        {
            Figure figure = Instantiate(spawnFigureDatas[i].FigureData.Figure,
                                        spawnPoints[i],
                                        Quaternion.Euler(0, 0, UnityEngine.Random.Range(0f, 360f)),
                                        _figureController.transform);

            figure.SetColor(spawnFigureDatas[i].FigureColorData);
            figure.SetAnimal(spawnFigureDatas[i].FigureAnimalData);

            _figureController.AddFigure(figure);
        }

    }

    public void RefreshFigures()
    {
        int newCount = (_levelManager.Level.SpotController.CountReserveSpot
                       + _levelManager.Level.FigureController.Figures.Count) / 3;

        _levelManager.Level.SpotController.Clear();
        _figureController.Clear();

        SpawnFigures(newCount);
    }

    private List<Vector3> GenerateSpawnPoints(int count)
    {
        List<Vector3> spawnPoints = new List<Vector3>();
        int spawnPointId = 0;
        float yCurrent = _spawnPoints[spawnPointId].position.y;

        while (spawnPoints.Count < count)
        {
            spawnPoints.Add(new Vector3(_spawnPoints[spawnPointId].position.x, yCurrent, 0));
            spawnPointId++;

            if (spawnPointId == _spawnPoints.Count)
            {
                spawnPointId = 0;
                yCurrent += _figureSize;
            }
        }

        return spawnPoints;
    }

    private List<SpawnFigureData> GenerateFigureDatas(int count)
    {
        List<SpawnFigureData> spawnFigureDatas = new List<SpawnFigureData>();

        for (int i = 0; i < count; i++)
        {
            SpawnFigureData spawnFigureData = new SpawnFigureData();
            spawnFigureData.FigureData = _figureGroupData.FigureDatas[Random.Range(0, _figureGroupData.FigureDatas.Count)];
            spawnFigureData.FigureColorData = _colorGroupData.FigureColorDatas[Random.Range(0, _colorGroupData.FigureColorDatas.Count)];
            spawnFigureData.FigureAnimalData = _animalGroupData.FigureAnimalDatas[Random.Range(0, _animalGroupData.FigureAnimalDatas.Count)];
            for (int j = 0; j < _countSameFigure; j++)
            {
                spawnFigureDatas.Add(spawnFigureData);
            }
        }

        spawnFigureDatas = ShuffleList(spawnFigureDatas);

        return spawnFigureDatas;
    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, list.Count);
            (list[n], list[k]) = (list[k], list[n]);
        }

        return list;
    }
}
