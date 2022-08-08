using UnityEngine;
using GameDevRunner.Collectables;

namespace GameDevRunner
{
    public class TriggerDetection : MonoBehaviour
    {
        private Player playerScript;
        private Worktable worktable;

        #region MonoBehaviour Methods
        private void Awake()
        {
            playerScript = transform.parent.GetComponentInParent<Player>();
            worktable = transform.parent.GetComponentInChildren<Worktable>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                other.GetComponent<CharacterAnimations>()?.PlaySittingAniamtion();
                worktable.AddCharacterToTable(other.gameObject);
                playerScript.IncreaseWorkerCount(other.GetComponent<Character>().Job);
                return;
            }
            else if (other.CompareTag("Collectable"))
            {
                playerScript.IncreaseGamePoint(other.GetComponent<CollectablePoints>().CollectableType);
                return;
            }
        }
        #endregion
    }
}