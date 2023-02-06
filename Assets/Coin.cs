using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float SpinSpeed = 1;
    public GameManager manager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            manager.IncreaseCoinCount();
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * (SpinSpeed * Time.deltaTime));
    }
}
