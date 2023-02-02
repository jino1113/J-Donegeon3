using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class BurningObject : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem>  m_BurningParticle;
    [SerializeField] private GameObject m_LavaPosGameObject;
    [SerializeField] private GameObject m_ParentGameObject;


    [Header("Debug")]
    [SerializeField] private float m_MaxBurningTime = 5;
    [SerializeField] private float m_Timer;

    void Start()
    {
        m_LavaPosGameObject = GameObject.Find("LavaPos");
        m_BurningParticle[0].GetComponent<ParticleSystem>();
        m_BurningParticle[1].GetComponent<ParticleSystem>();
        m_BurningParticle[2].GetComponent<ParticleSystem>();

    }



    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= m_MaxBurningTime)
            {
                if (m_ParentGameObject != null)
                {
                    Destroy(m_ParentGameObject);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            m_Timer = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            Instantiate(m_BurningParticle[0], m_LavaPosGameObject.transform.position, Quaternion.identity);
            Instantiate(m_BurningParticle[1], m_LavaPosGameObject.transform.position, Quaternion.identity);
            Instantiate(m_BurningParticle[2], m_LavaPosGameObject.transform.position, Quaternion.identity);


            m_BurningParticle[0].Play();
            m_BurningParticle[1].Play();
            m_BurningParticle[2].Play();
        }

        if (other.gameObject.tag == "Destroy")
        {
            if (m_ParentGameObject != null)
            {
                Destroy(m_ParentGameObject);
            }
            Destroy(gameObject);
        }
    }

}
