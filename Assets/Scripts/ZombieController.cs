using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public Animator animator;
    private NavMeshAgent mNavMeshAgent;
    private Vector3 mLastPosition;
    private Collider mCollider;
    private Rigidbody mRigidBody;
    public bool isDead { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mNavMeshAgent.SetDestination(new Vector3(3.93f, 0, -2.63f));
        mCollider = GetComponent<Collider>();
        mRigidBody = GetComponent<Rigidbody>();
        isDead = false;
    }

    public void StartDead()
    {
        isDead = true;
        animator.SetTrigger("Dead");
        mNavMeshAgent.isStopped = true;

        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    private void LateUpdate()
    {
        animator.SetFloat("MoveSpeed", mNavMeshAgent.velocity.magnitude * 5);
    }
}
