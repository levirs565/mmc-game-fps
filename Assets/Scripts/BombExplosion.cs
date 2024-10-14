using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private ZombieManager mZombieManager;

    void Start()
    {
        mZombieManager = FindFirstObjectByType<ZombieManager>();
    }
   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie;
        other.TryGetComponent<ZombieController>(out zombie);

        if (zombie != null && !zombie.isDead)
        {
            mZombieManager.KillZombieAt(gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
