using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public TextMeshProUGUI ammoDisplay;

    public void SetAmmoDisplay(int loadedAmmo, int ammoCapacity) {
        ammoDisplay.SetText("{0} / {1}", loadedAmmo, ammoCapacity);
    }

    public void OnHit() {
        Debug.Log("Game Over!");
    }
}
