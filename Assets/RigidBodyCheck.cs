using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCheck : MonoBehaviour
{

    [Header("RunnerManager")]
    [SerializeField] private RunnerManager m_runnerManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "PlaneBorder")
        {
            m_runnerManager.ResetRunner(m_runnerManager);
        }
    }
}
