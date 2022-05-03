using System;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed = 5f;

    public int pointsWorth = 1;
    
    private Animator animator;

    private PlayerController playerController;
    
    private GameObject playerCamera;

    private Vector3 targetPosition;

    private Rigidbody _rigidbody;

    bool close = false;

    // Start is called before the first frame update
    void Start() {
        animator = gameObject.GetComponent<Animator>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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
        animator.SetInteger("legs", 5);
        animator.SetInteger("arms", 34);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            close = true;
            StopMovement();
        }
    }

    public void OnHitPlayer() {
        Debug.Log("Hit");
        playerController.OnHit();
    }

    public void Hit() {
        playerController.AddScore(pointsWorth);
        Destroy(gameObject);
    }
}