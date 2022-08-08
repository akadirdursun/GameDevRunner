using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    public class CharacterAnimations : MonoBehaviour
    {
        private Animator myAnimator;

        #region MonoBehaviour METHODS
        private void Awake()
        {
            myAnimator = GetComponentInChildren<Animator>();
        }
        #endregion

        public void PlaySittingAniamtion()
        {
            myAnimator.SetBool("Collected", true);
        }
    }
}