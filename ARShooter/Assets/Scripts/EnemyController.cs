using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyController : MonoBehaviour {
    public float speed = 5f;

    public int pointsWorth = 1;

    private SpawnController _spawnController;
    
    private Animator _animator;

    private PlayerController _playerController;
    
    private GameObject _playerCamera;

    private Rigidbody _rigidbody;

    private bool _close = false;

    // Start is called before the first frame update
    void Start() {
        _animator = gameObject.GetComponent<Animator>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _playerCamera = GameObject.Find("PlayerCamera");
        StartCoroutine(UpdatePlayerPosition());
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _spawnController = GlobalInformationController.Instance.SpawnController;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (_close) return;
        var targetPosition = _playerCamera.transform.position;
        targetPosition.y -= 1.75f;
        transform.LookAt(targetPosition);
        var thisRotation = transform.rotation;
        transform.Rotate(thisRotation.x, thisRotation.y + 90, thisRotation.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private IEnumerator UpdatePlayerPosition() {
        while (true) {
            

            yield return new WaitForSeconds(1f);
        }
    }
    
    private void StopMovement() {
        _rigidbody.velocity = Vector3.zero;
        _animator.SetInteger("legs", 5);
        _animator.SetInteger("arms", 34);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _close = true;
            StopMovement();
        }
    }

    public void OnHitPlayer() {
        Debug.Log("Hit");
        _playerController.OnHit();
    }

    public void Hit() {
        _playerController.AddScore(pointsWorth);
        _spawnController.EnemyGotHit();
        Destroy(gameObject);
    }
}