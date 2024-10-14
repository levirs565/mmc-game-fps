using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    private List<ZombieController> mZombies;

    void Awake()
    {
        mZombies = new List<ZombieController>(); 
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RegisterZombie(ZombieController controller)
    {
        mZombies.Add(controller);
    }

    public void UnregisterZombie(ZombieController controller)
    {
        mZombies.Remove(controller);
    }

    List<ZombieController> GetZombiesAt(Vector3 center)
    {
        List<ZombieController> result = new List<ZombieController>();
        var overlapped = Physics.OverlapBox(center, new Vector3(1f, 2f, 1f));

        foreach (var collider in overlapped)
        {
            ZombieController zombie;
            collider.TryGetComponent<ZombieController>(out zombie);

            if (zombie != null)
            {
                result.Add(zombie);
            }
        }

        return result;
    }

    public void KillZombieAt(Vector3 center)
    {
        foreach (var zombie in GetZombiesAt(center))
        {
            if (zombie.isDead) continue;
            zombie.StartDead();
        }
    }

    public void SlowDownAt(Vector3 center)
    {
        foreach (var zombie in GetZombiesAt(center))
        {
            if (zombie.isDead) continue;
            zombie.SlowDown();
        }
    }
}
