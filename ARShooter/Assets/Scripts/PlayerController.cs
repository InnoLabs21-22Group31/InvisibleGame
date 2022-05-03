using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public TextMeshProUGUI ammoDisplay;
    public TextMeshProUGUI scoreDisplay;
    private int _score = 0;

    public void SetAmmoDisplay(int loadedAmmo, int ammoCapacity) {
        ammoDisplay.SetText("{0} / {1}", loadedAmmo, ammoCapacity);
    }

    public void OnHit() {
        Debug.Log("Game Over!");
    }

    public void AddScore(int scoreToAdd) {
        _score += scoreToAdd;
        scoreDisplay.SetText(_score.ToString());
    }
}
