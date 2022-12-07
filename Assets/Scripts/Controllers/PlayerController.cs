using System.Collections;
using UnityEngine;

[System.Serializable]
public enum SIDE
{
    LEFT,
    MID,
    RIGHT
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SIDE side = SIDE.MID;
    [SerializeField] private float _offsetBetweenPaths;
    [SerializeField] private GameObject _leftPath;
    [SerializeField] private GameObject _middlePath;
    [SerializeField] private GameObject _rightPath;
    private float _newXAxisPosition = 0f;
    private CharacterController _characterController;

    private Animator _animator;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Detect if one finger or more touch the screen then get the phase of the first
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(0).position;
        }

        // To get the direction of the swipe we compare the finger's position at the beginning and at the end (when leaving the screen)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            // Left swipe
            if (_endTouchPosition.x < _startTouchPosition.x)
            {
                if (side == SIDE.MID)
                {
                    side = SIDE.LEFT;
                    
                    // transform.Translate(Vector3.right * _offsetBetweenPaths);
                    //transform.position = _leftPath.transform.position;
                    // SmoothLerp(0.3f);
                    Debug.Log("Left Swipe");
                    _animator.SetTrigger("Left Swipe");
                    _animator.enabled = false;
                    SmoothLerp(1f);
                    //_animator.enabled = true;
                }

                else if (side == SIDE.RIGHT)
                {
                    side = SIDE.MID;
                    transform.position = _middlePath.transform.position;
                }
            }

            // Right swipe
            else if (_endTouchPosition.x > _startTouchPosition.x)
            {
                if (side == SIDE.MID)
                {
                    side = SIDE.RIGHT;
                    transform.position = _rightPath.transform.position;
                }

                else if (side == SIDE.LEFT)
                {
                    side = SIDE.MID;
                    transform.position = _middlePath.transform.position;
                }
            }
        }
    }

    private IEnumerator ApplyDelay(float delay)
    {
        Debug.Log("Call");
        yield return new WaitForSeconds(0.1f);
    }

    // Fonction qui s'exécute au fil du temps
    private IEnumerator SmoothLerp(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position + (transform.forward * 5);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
    }
}
