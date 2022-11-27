using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoBehaviour
{
    [Header("Perso")]
    [SerializeField] private GameObject m_character;
    [SerializeField] private GameObject m_camera;
    private Vector3 m_characterInit;
    private Vector3 m_cameraInit;

    [Header("Target Point")]
    [SerializeField] private List<GameObject> m_targetPoints;
    private int m_path = 1;

    [Header("Teleport Asignment")]
    [SerializeField] GameObject m_teleportPlane;

    // Start is called before the first frame update
    void Start()
    {
        m_characterInit = m_character.transform.position;
        m_cameraInit = m_camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        WalkToTarget();

        ChangePathing();
    }

    void WalkToTarget()
    {
        m_character.transform.forward = Vector3.RotateTowards(m_character.transform.forward, new Vector3(0, m_targetPoints[m_path].transform.position.y, m_targetPoints[m_path].transform.position.z) - new Vector3(0, m_character.transform.position.y, m_character.transform.position.z), 10 * Time.deltaTime, 0.0f);

        m_character.transform.rotation = new Quaternion(0, 180, 0, 0);

        Vector3 MoveVectorCharacter = Vector3.MoveTowards(m_character.transform.position, m_targetPoints[m_path].transform.position, 10 * Time.deltaTime);

        m_character.transform.position = new Vector3(MoveVectorCharacter.x, 7.5f, MoveVectorCharacter.z);

        m_camera.transform.forward = Vector3.RotateTowards(m_camera.transform.forward, new Vector3(0, m_targetPoints[1].transform.position.y, m_targetPoints[1].transform.position.z) - new Vector3(0, m_camera.transform.position.y, m_camera.transform.position.z), 10 * Time.deltaTime, 0.0f);

        m_camera.transform.eulerAngles = new Vector3(11.95f, 180, 0);

        Vector3 MoveVectorCamera = Vector3.MoveTowards(m_camera.transform.position, m_targetPoints[1].transform.position, 10 * Time.deltaTime);

        m_camera.transform.position = new Vector3(MoveVectorCamera.x, 11.4f, MoveVectorCamera.z);
    }

    public void ResetRunner(RunnerManager runnerManager)
    {
        Debug.Log("PROUT");
        if(m_path == 0)
        {
            m_character.transform.position = m_characterInit - new Vector3(4,0,0);
        }
        else if(m_path == 1)
        {
            m_character.transform.position = m_characterInit;
        }
        else if(m_path == 2)
        {
            m_character.transform.position = m_characterInit - new Vector3(-4, 0, 0);
        }

        m_camera.transform.position = m_cameraInit;
    }

    void ChangePathing()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log(m_path);
            if (m_path < 2)
            {
                m_path++;
                m_character.transform.position = new Vector3(m_character.transform.position.x + 4, m_character.transform.position.y, m_character.transform.position.z);
                Debug.Log(m_path);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log(m_path);
            if (m_path > 0)
            {
                m_path--;
                m_character.transform.position = new Vector3(m_character.transform.position.x - 4, m_character.transform.position.y, m_character.transform.position.z);
                Debug.Log(m_path);
            }
        }
    }
}
