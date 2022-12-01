using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _leftPath;
    [SerializeField] private GameObject _middlePath;
    [SerializeField] private GameObject _rightPath;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

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
                // If the caracter is on the right path
                if (transform.position.x == _rightPath.transform.position.x)
                {
                    transform.position = _middlePath.transform.position;
                    Debug.Log("Right -> Middle");
                }

                // If the caracter is on the middle path
                else if (transform.position.x == _middlePath.transform.position.x)
                {
                    transform.position = _leftPath.transform.position;
                    Debug.Log("Middle -> Left");
                }
            }

            // Right swipe
            else if (_endTouchPosition.x > _startTouchPosition.x)
            {
                // If the caracter is on the left path
                if (transform.position.x == _leftPath.transform.position.x)
                {
                    transform.position = _middlePath.transform.position;
                    Debug.Log("Left -> Middle");
                }

                // If the caracter is on the middle path
                else if (transform.position.x == _middlePath.transform.position.x)
                {
                    transform.position = _rightPath.transform.position;
                    Debug.Log("Middle -> Right");
                }
            }
        }
    }
}
