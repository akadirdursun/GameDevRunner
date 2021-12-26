using UnityEngine;

namespace GameDevRunner
{
    [CreateAssetMenu(menuName ="Game Size",fileName ="NewGameSize")]
    public class GameSize: ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private int pointToComplete;

        public string Name { get => name; }
        public int PointToComplete { get => pointToComplete; }
    }
}