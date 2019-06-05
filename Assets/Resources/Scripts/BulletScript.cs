using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifetime;
    private void Awake()
    {
        StartCoroutine(shotlife());
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }

    private void Update()
    {
        Debug.Log(gameObject.transform.rotation);
    }

    IEnumerator shotlife()
    {
        yield return new WaitForSeconds(lifetime);
        {
            Destroy(gameObject);
        }
    }
}
