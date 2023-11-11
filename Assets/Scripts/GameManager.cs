using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isNext { get; set; }

    [SerializeField] private GameObject[] seedPrefab;
    [SerializeField] private Transform seedPosition;

    void Start()
    {
        Instance = this;
        isNext = false;
        CreateSeed();
    }
    void Update()
    {
        if (isNext)
        {
            isNext = false;
            Invoke("CreateSeed", 2f);
        }
    }
    private void CreateSeed()
    {
        int i = Random.Range(0, seedPrefab.Length - 2);
        Instantiate(seedPrefab[i], seedPosition);
    }
}