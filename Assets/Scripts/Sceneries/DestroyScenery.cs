using UnityEngine;

public class DestroyScenery : MonoBehaviour
{
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        if (transform.position.z >= _player.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
