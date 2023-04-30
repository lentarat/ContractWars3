using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private GameObject _grenadePrefab;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Transform _positionToTrow;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _UpwardForce;
    [SerializeField] private float _explosionSpeed;
    public float delay = 3f;
    public float radius = 20f;
    public int quantityGranade = 3;
   // private bool _enabledToTrow = true;
    [SerializeField] private Camera _cam ;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }
    private void InputHandler()
    {
        if(Input.GetKeyDown(KeyCode.G) && quantityGranade > 0) 
        {
            StartCoroutine(GrendeHendle());
        }
    }

    public IEnumerator GrendeHendle()
    {
        quantityGranade--;
        GameObject projectile = Instantiate(_grenadePrefab, _positionToTrow.transform.position, _positionToTrow.transform.rotation);
        
        Rigidbody projecrileRB = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = _cam.transform.forward * _explosionForce + gameObject.transform.up * _UpwardForce;

        projecrileRB.AddForce(forceToAdd, ForceMode.Impulse);
        yield return new WaitForSeconds(delay);
        GameObject explotion = Instantiate(_explosionPrefab, projectile.transform.position, projectile.transform.rotation);
        Destroy(projectile);
        yield return new WaitForSeconds(delay);
        Destroy(explotion);
        
    }

}
