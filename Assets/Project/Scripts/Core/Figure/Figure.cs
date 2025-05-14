using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : FigureBase
{
    [SerializeField] private FrameType _frameType;
    [SerializeField] private SpriteRenderer _frameSprite;
    [SerializeField] private SpriteRenderer _colorSprite;
    [SerializeField] private SpriteRenderer _animalSprite;
    [SerializeField] private Rigidbody2D _rb;

    [Space(10)]
    [SerializeField] private FigureMover _mover;

    private ColorType _colorType;
    private AnimalType _animalType;

    public FrameType FrameType => _frameType;
    public ColorType ColorType => _colorType;
    public AnimalType AnimalType => _animalType;
    public FigureMover Mover => _mover;

    public void SetColor(FigureColorData figureColorData)
    {
        _colorType = figureColorData.ColorType;
        _colorSprite.color = figureColorData.Color;
    }

    public void SetAnimal(FigureAnimalData figureAnimalData)
    {
        _animalType = figureAnimalData.AnimalType;
        _animalSprite.sprite = figureAnimalData.AnimalSprite;
    }

    public void SetOrderLayer(int value)
    {
        _frameSprite.sortingOrder = value;
        _colorSprite.sortingOrder = value;
        _animalSprite.sortingOrder = value + 1;
    }

    public bool Equals(Figure figure)
    {
        if (figure == null)
        {
            return false;
        }

        return _frameType == figure.FrameType &&
               _colorType == figure.ColorType &&
               _animalType == figure.AnimalType;
    }

    public void ActiveRB(bool value)
    {
        _rb.simulated = value;
    }

    public void StopSimulate()
    {
        _rb.simulated = false;
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0;
        _rb.simulated = true;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
