using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : FigureBase
{
    [SerializeField] private FrameType _frameType;
    [SerializeField] private SpriteRenderer _colorSprite;
    [SerializeField] private SpriteRenderer _animalSprite;

    private ColorType _colorType;
    private AnimalType _animalType;

    public FrameType FrameType => _frameType;
    public ColorType ColorType => _colorType;
    public AnimalType AnimalType => _animalType;

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

    public bool Equals(Figure figure)
    {
        return _frameType == figure.FrameType &&
               _colorType == figure._colorType &&
               _animalType == figure._animalType;
    }
}
