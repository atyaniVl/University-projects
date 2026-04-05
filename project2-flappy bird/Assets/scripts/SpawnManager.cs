using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject rocks;
    [SerializeField] GameObject _rocksParent;
    void Start()
    {
        InvokeRepeating("spawnRocks",Random.Range(3,6),Random.Range(1,2.5f));
    }

    public void spawnRocks()
    {
        GameObject clone = Instantiate(rocks, new Vector3(6.3f, Random.Range(-1.97f, 4.14f), 0), Quaternion.identity);
        clone.transform.parent = _rocksParent.transform;
    }
    public void stopSpawner()
    {
        CancelInvoke();
        Destroy(_rocksParent);
    }

}
