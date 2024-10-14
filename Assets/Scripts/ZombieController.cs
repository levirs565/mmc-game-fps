using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent mNavMeshAgent;
    private ZombieManager mZombieManager;
    private float mDefaultSpeed;
    private Coroutine mResetSlowDownCoroutine;

    public Animator animator;
    public bool isDead { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        mZombieManager = FindFirstObjectByType<ZombieManager>();
        mZombieManager.RegisterZombie(this);

        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mNavMeshAgent.SetDestination(new Vector3(3.93f, 0, -2.63f));

        isDead = false;

        mDefaultSpeed = mNavMeshAgent.speed;
    }

    public void SlowDown()
    {
        if (mResetSlowDownCoroutine != null)
            StopCoroutine(mResetSlowDownCoroutine);

        mResetSlowDownCoroutine = StartCoroutine(DelayResetSpeed());
        mNavMeshAgent.speed = 0.1f;
    }

    public IEnumerator DelayResetSpeed()
    {
        yield return new WaitForSeconds(15);
        mNavMeshAgent.speed = mDefaultSpeed;
    }

    public void StartDead()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Dead");
        mNavMeshAgent.isStopped = true;
        mZombieManager.UnregisterZombie(this);

        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    void Update()
    {
          
    }

    private void LateUpdate()
    {
        animator.SetFloat("MoveSpeed", mNavMeshAgent.velocity.magnitude * 5);
    }
}
