using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPack : MonoBehaviour
{
    // Start is called before the first frame update

    public float fuel, speed, reverseGravity, flyingforce;
    public float maxSpeed;
    public Camera _camera;
    Gorevler _gorevler;
    public Text eyebas;

    public bool _gotJetpack = false;
    Ray _ray;

    private string _jetpackalindi = "Benzin";

    Rigidbody rigid;
    RaycastHit hit;
    public GameObject _objJetpack;

    void Start()
    {
        _gorevler = GetComponent<Gorevler>();
        fuel = 10f;
        rigid = transform.GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (_gotJetpack == true)
        {
            rigid.AddForce(transform.up * reverseGravity);
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
        }
        else
        {
            rigid.AddForce(transform.up * (reverseGravity/1.3f));
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed/1.3f);
        }



        
        if (Input.GetKey(KeyCode.Space) && _gotJetpack == true)
        {
            fuel -= 0.002f;
            rigid.AddForce(-transform.up * flyingforce);
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
        }
        if(Input.GetKey(KeyCode.W))
        {
            if (_gotJetpack == true)
                fuel -= 0.002f;
            rigid.AddForce(transform.forward * speed);
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (_gotJetpack == true)
                fuel -= 0.002f;
            rigid.AddForce(transform.right * speed);
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (_gotJetpack == true)
                fuel -= 0.002f;
            rigid.AddForce(-transform.right * speed);
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (_gotJetpack == true)
                fuel -= 0.002f;
            rigid.AddForce(-transform.forward * speed);
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
        }
        if(Physics.Raycast(_ray,out hit))
        {
            if(hit.transform.gameObject == _objJetpack)
            {
                eyebas.gameObject.SetActive(true);
            }
            else if(hit.transform.gameObject != _objJetpack)
            {
                eyebas.gameObject.SetActive(false);
            }
            if (hit.transform.gameObject == _objJetpack && Input.GetKey(KeyCode.E))
            {
                Destroy(_objJetpack);
                _gotJetpack = true;
                _gorevler.currentGorev = _jetpackalindi;
            }
        }
        }

}
