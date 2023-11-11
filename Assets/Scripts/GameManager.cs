using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject seedPrefab;
    [SerializeField] private Transform seedPosition;

    void Start()
    {
        CreateSeed();
    }

    private void CreateSeed()
    {
        Instantiate(seedPrefab, seedPosition);
    }
}