using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _ignoreRayCast;
    [SerializeField] private LayerMask _inputLayer;

    private SpotController _spotController;
    private bool _active;

    [Inject]
    public void Construct(LevelManager levelManager)
    {
        _spotController = levelManager.Level.SpotController;
    }

    private void Update()
    {
        if (!_active) return;

        if (Input.GetMouseButtonDown(0))
        {
            Touch();
        }
    }

    public void SetActive(bool value)
    {
        _active = value;
    }

    private void Touch()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayOrigin = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, _inputLayer);
        if (hit.collider != null && hit.transform.TryGetComponent<Figure>(out Figure figure))
        {
            if (_spotController.TryAddFigure(figure))
            {
                figure.gameObject.layer = Mathf.RoundToInt(Mathf.Log(_ignoreRayCast.value, 2));
            }
        }
    } 
}
