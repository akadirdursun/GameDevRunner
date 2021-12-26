using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameDevRunner
{
    public abstract class Door : MonoBehaviour
    {
        [Header("Visualization")]
        [SerializeField] protected TextMeshPro nameText;
        [SerializeField] protected SpriteRenderer spriteRenderer;

        private void OnTriggerEnter(Collider other)
        {
            SetSelection(other.GetComponentInParent<Player>());
        }

        protected abstract void SetSelection(Player _playerScript);
    }
}