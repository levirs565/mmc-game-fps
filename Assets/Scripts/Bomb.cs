using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private ZombieManager mZombieManager;

    // Start is called before the first frame update
    void Start()
    {
        mZombieManager = FindFirstObjectByType<ZombieManager>();
    }

    // Update is called once per frame
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
        }
    }
}
