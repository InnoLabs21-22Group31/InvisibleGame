using UnityEngine;

public class Gun : MonoBehaviour {
    public Camera playerCamera;
    public float range = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            Fire();
        }
    }

    private void Fire() {
        RaycastHit hit;

        // Fire straight ahead
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range)) {
            var hitGO = hit.transform.gameObject;

            if (hitGO && hitGO.CompareTag("Enemy")) {
                var hitGOScript = hitGO.GetComponent<EnemyController>();
                if (hitGOScript) {
                    hitGOScript.Hit();
                }
            }
        }
    }
}
