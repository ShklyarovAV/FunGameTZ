using UnityEngine;

[CreateAssetMenu(fileName = "FigureAnimal", menuName = "FigureCharacteristic/FigureAnimal")]
public class FigureAnimalData : ScriptableObject
{
    [SerializeField] private AnimalType _animalType;
    [SerializeField] private Sprite _animalSprite;

    public AnimalType AnimalType => _animalType;
    public Sprite AnimalSprite => _animalSprite;
}
