﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.Collectables
{
    public class CollectablePoints : MonoBehaviour
    {
        [SerializeField] private CollectableTypes collectableType;

        public CollectableTypes CollectableType
        {
            get
            {
                Destroy(gameObject);
                return collectableType;
            }
        }
    }
}