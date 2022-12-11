using UnityEngine;

public class MoveScenery : MonoBehaviour
{
    [SerializeField] private float _translationSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _translationSpeed);
    }
}
