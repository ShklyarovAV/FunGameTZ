using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class FigureMover : MonoBehaviour
{
    public void Move(Vector3 target, UnityAction callBack = null)
    {
        transform.DOMove(target, .5f).OnComplete(() => callBack?.Invoke());
        transform.DORotate(new Vector3(0, 0, 0), .5f);
    }
}
