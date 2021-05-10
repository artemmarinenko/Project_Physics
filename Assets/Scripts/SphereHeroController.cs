using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereHeroController : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _timeForExplosion;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private Text _text;

    private void Awake()
    {
        GameEvents.OnCatpultClick += OnCatapultClickHandler;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Catapult catapult)) {

            GetComponent<MeshRenderer>().material.color = Color.black;
            GameEvents.RaiseOnMissleLanded();
        }
            
       
    }


    private void OnCatapultClickHandler()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;

        StartCoroutine(WaitForSecondsThenExplode(_timeForExplosion));

    }

    IEnumerator WaitForSecondsThenExplode(float seconds)
    {
        StartCoroutine(Timer(seconds));

        yield return new WaitForSeconds(seconds);
        Collider[] collidersToExplode = Physics.OverlapSphere(gameObject.GetComponent<Collider>().bounds.center, _explosionRadius, _layerMask);
        Destroy(gameObject);

        foreach(Collider col in collidersToExplode)
        {
            col.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, gameObject.GetComponent<Collider>().bounds.center, _explosionRadius);
            col.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    IEnumerator Timer(float seconds)
    {
        while (seconds > 0.1) {
            seconds -= Time.deltaTime;
            _text.text = seconds.ToString();
            yield return null;
        }
        _text.text = StringConstants.ExplosionMessage;
        
    }
}
