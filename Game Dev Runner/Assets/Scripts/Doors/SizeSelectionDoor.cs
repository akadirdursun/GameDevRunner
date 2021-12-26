using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    public class SizeSelectionDoor : Door
    {
        [Space]
        [SerializeField] private GameSize sizeInfo;

        private void Start()
        {
            if (sizeInfo != null)
            {
                nameText.text = sizeInfo.name;
            }
        }

        protected override void SetSelection(Player _playerScript)
        {
            if (_playerScript == null) return;

            _playerScript.GameInfo.Size = sizeInfo;
        }
    }
}