using UnityEngine;

namespace GameDevRunner
{
    public class GenreSelectionDoor : Door
    {
        [Space]
        [SerializeField] private GameGenres genreInfo;

        private void Start()
        {
            if (genreInfo != null)
            {
                nameText.text = genreInfo.GenreName;
                spriteRenderer.sprite = genreInfo.GenreIcon;
            }
        }

        protected override void SetSelection(Player _playerScript)
        {
            if (_playerScript == null) return;

            _playerScript.GameInfo.SetGenre(genreInfo);
        }
    }
}