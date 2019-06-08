using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float _gameFieldSize = 10;

    public static float gameFieldSize { get; private set; }

    private void Awake()
    {
        gameFieldSize = _gameFieldSize;
    }
}
