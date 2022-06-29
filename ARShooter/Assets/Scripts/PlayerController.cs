using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class PlayerController : MonoBehaviour {
    public TextMeshProUGUI ammoDisplay;
    public TextMeshProUGUI scoreDisplay;

    [SerializeField] private GameObject drawnWeapon;
    [SerializeField] private ARPlaneManager arPlaneManager;
    
    private int _score = 0;

    public void SetAmmoDisplay(int loadedAmmo, int ammoCapacity) {
        ammoDisplay.SetText("{0} / {1}", loadedAmmo, ammoCapacity);
    }

    public void OnHit() {
        Destroy(drawnWeapon);
        SetAmmoDisplay(0, 0);
        arPlaneManager.enabled = false;
        SceneManager.LoadScene("EndScreen");
        var globalInformation = GlobalInformationController.Instance;
        globalInformation.score = _score;
        globalInformation.wave = transform.GetComponentInChildren<SpawnController>().waveNumber-1;
    }

    public void AddScore(int scoreToAdd) {
        _score += scoreToAdd;
        scoreDisplay.SetText(_score.ToString());
    }
}
