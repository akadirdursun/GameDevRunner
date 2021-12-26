using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    [CreateAssetMenu(menuName = "New Game Genre", fileName = "NewGameGenre")]
    public class GameGenres : ScriptableObject
    {
        [SerializeField] private string genreName;
        [SerializeField] private Sprite genreIcon;
        [Header("Multipliers")]
        [SerializeField] private CollectableTypes primaryType;
        [SerializeField] private CollectableTypes secondaryType;

        public string GenreName { get => genreName; }
        public Sprite GenreIcon { get => genreIcon; }
        public CollectableTypes PrimaryType { get => primaryType; }
        public CollectableTypes SecondaryType { get => secondaryType; }
    }
}