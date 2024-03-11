using UnityEngine;

public class CamScript : MonoBehaviour
{
    //TP2Vintar

    [SerializeField]
    Camera _camRef;

    Ray _rayCam;
    [SerializeField]
    float _armLenght = 2;

    Vector3 _direcCam;

    RaycastHit _rayHit;

    bool _isCamBlock;
    [SerializeField]
    GameObject _wall;

    [SerializeField]
    Vector3 offset;

    Material _render;

    Color _color;

    public GameObject player;

    private void Awake()
    {
        _camRef = GetComponentInChildren<Camera>();
        if (_camRef == null)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //comprueba si hay un objeto entre la camara y el jugador
        _direcCam = (_camRef.transform.position - transform.position).normalized;

        _rayCam = new Ray(transform.position, _direcCam);

        _isCamBlock = Physics.Raycast(_rayCam, out _rayHit, _armLenght);
        if (_isCamBlock )
            _wall = _rayHit.collider.gameObject;
        else if (_wall != null && _wall.layer == 10)       
        {
            _color.a = 1f;
            _render.color = _color;
            _wall = null;
        }

    }
    public bool ejeX;
    public bool ejeY;
    private void OnTriggerEnter(Collider other)
    {
        ejeX = (other.gameObject.layer == 8);
        ejeY = (other.gameObject.layer == 9);
        
    }
    Vector3 dir;
    void LateUpdate()
    {
        
        dir = player.transform.position + offset;

        if (_wall != null && _wall.layer == 10)
        {
            Opacity();
        }
        if (ejeX)        
            dir.y = 0;
        else if (ejeY)
            dir.x = 0;

        transform.position = dir;

    }



    void Opacity()
    {
        //Cambia la opacidad de la pared
        if (_isCamBlock )
        {
            _render = _wall.GetComponent<MeshRenderer>().material;
            Color currentColor = _render.color;
            _color = currentColor;
            currentColor.a = 0.2f;
            _render.color = currentColor;

        }
        

    }
    //solo se usa para ver Gizmos 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);

        if (_camRef)
        {
            Gizmos.DrawSphere(_camRef.transform.position, 01f);
        }

        Gizmos.color = _isCamBlock ? Color.red : Color.green;

        if (_camRef)
        {
            Gizmos.DrawLine(transform.position, _camRef.transform.position);
        }

    }
}
