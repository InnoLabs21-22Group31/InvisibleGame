using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour {
    public float speed = 5f;

    private Animator animator;

    private GameObject playerCamera;

    private Vector3 targetPosition;

    bool close = false;
    
    // Start is called before the first frame update
    void Start() {
        animator = gameObject.GetComponent<Animator>();
        playerCamera = GameObject.Find("Main Camera");
        targetPosition = playerCamera.transform.position;
        targetPosition.y = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!close) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            transform.LookAt(targetPosition);
            var thisRotation = transform.rotation;
            transform.Rotate(thisRotation.x, thisRotation.y + 90, thisRotation.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyRadius"))
        {
            close = true;
        }
        else
        {
            close = false;
        }
    }
}