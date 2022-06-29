using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInformationController : MonoBehaviour
{
    public static GlobalInformationController Instance { get; private set; }

    public SpawnController SpawnController;

    public int score = 0;
    public int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null) return;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
