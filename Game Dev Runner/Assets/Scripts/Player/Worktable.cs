using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    public class Worktable : MonoBehaviour
    {
        [SerializeField] private List<Transform> position = new List<Transform>();
        [SerializeField] private List<GameObject> characters = new List<GameObject>();        

        public void AddCharacterToTable(GameObject _character)
        {
            characters.Add(_character);
            _character.GetComponent<Collider>().enabled = false;
            int i = characters.IndexOf(_character);
            _character.transform.parent = position[i];
            _character.transform.localPosition = Vector3.zero;
            _character.transform.localEulerAngles = Vector3.zero;
        }
    }
}