using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopUpText : MonoBehaviour
{
    private void OnEnable()
    {
        PopUpRoutine();
    }

    private void PopUpRoutine()
    {
        transform.DOMoveY(transform.position.y + 2f, 1f).OnComplete(() => { Destroy(gameObject); });
    }
}
