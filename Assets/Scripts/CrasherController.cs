using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrasherController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Text _text;
    void Awake()
    { 
        _rigidBody = GetComponent<Rigidbody>();
        GameEvents.OnSphereHeroClick += OnClickHandler;
    }

    private void OnClickHandler()
    {
        _text.text = string.Empty;
        _rigidBody.constraints = RigidbodyConstraints.None;
    }
}
