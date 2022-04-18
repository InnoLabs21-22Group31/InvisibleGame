using System;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed = 5f;

    private Animator animator;

    private GameObject playerCamera;

    private Vector3 targetPosition;

    private Rigidbody _rigidbody;

    bool close = false;

    // Start is called before the first frame update
    void Start() {
        animator = gameObject.GetComponent<Animator>();
        playerCamera = GameObject.Find("PlayerCamera");
        targetPosition = playerCamera.transform.position;
        targetPosition.y = 0;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (!close) {
            transform.LookAt(targetPosition);
            var thisRotation = transform.rotation;
            transform.Rotate(thisRotation.x, thisRotation.y + 90, thisRotation.z);
            _rigidbody.AddRelativeForce(new Vector3(-1, 0, 0) * speed * Time.deltaTime,ForceMode.Force);
        }
    }

    private void StopMovement() {
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Game over");
            close = true;
            StopMovement();
        }
        else {
            close = false;
        }
    }
}