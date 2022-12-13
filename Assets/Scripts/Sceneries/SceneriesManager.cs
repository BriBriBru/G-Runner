using UnityEngine;

public class SceneriesManager : MonoBehaviour
{
    [SerializeField] private GameObject _spawn1;
    [SerializeField] private GameObject _spawn2;
    [SerializeField] private GameObject _spawn3;
    [SerializeField] private GameObject _spawn4;

    private GameObject _detectedGo;

    void OnTriggerEnter(Collider other)
    {
        // If we detect a scenery like a tree and a house 
        if (other.gameObject.tag == "Scenery")
        {
            _detectedGo = other.gameObject;

            // We choose a random spawn point among 4
            int randomNumber = Random.Range(0, 4);

            switch (randomNumber)
            {
                case 0:
                    _detectedGo.transform.position = _spawn1.transform.position;
                    break;
                case 1:
                    _detectedGo.transform.position = _spawn2.transform.position;
                    break;
                case 2:
                    _detectedGo.transform.position = _spawn3.transform.position;
                    break;
                case 3:
                    _detectedGo.transform.position = _spawn4.transform.position;
                    break;
                default:
                    return;
            }
        }
    }
}
