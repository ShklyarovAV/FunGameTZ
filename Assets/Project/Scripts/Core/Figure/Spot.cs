using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    private Figure _figure;
    private bool _reserved;

    public bool IsEmpty => _figure == null && _reserved == false;
    public Figure Figure => _figure;

    public void Push(Figure figure)
    {
        _figure = figure;
    }

    public void Reserve()
    {
        _reserved = true;
    }

    public void Release()
    {
        _figure.Destroy();
        _figure = null;
        _reserved = false;
    }
}
