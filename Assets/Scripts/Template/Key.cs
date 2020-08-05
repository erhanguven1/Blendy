using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	private float speed = 30f;
    public ParticleSystem BigStarParticle;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GamePlayManager.Instance.KeyUIFlow();
            var particle = Instantiate(BigStarParticle);
            particle.transform.position = transform.position;
            gameObject.SetActive(false);
            
        }
    }
}
