using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    [SerializeField] private Figure _figure;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private int _spawnWidth = 3;
    [SerializeField] private float _figureSize = 1;
    [SerializeField] private float _figureOffset = .1f;
    [SerializeField] private float _spawnDelay = .15f;

    //private void Start()
    //{
    //    StartCoroutine(SpawnFigures());
    //}

    //public IEnumerator SpawnFigures()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        yield return ;
    //    }
    //}
}
