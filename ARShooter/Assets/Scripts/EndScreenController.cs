using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI waveDisplay;

    private void Start() {
        var globalInformation = GlobalInformationController.Instance;
        scoreDisplay.SetText($"Score: {globalInformation.score}");
        waveDisplay.SetText($"Wave: {globalInformation.wave}");
    }

    public void RestartGame() {
        SceneManager.LoadScene("MainScene");
    }
}
