using UnityEngine;
public class Player : MonoBehaviour
{

    //TP2 Vintar
    public Movement movement;
    public Controller controller;
    Pause pause;
    public EmpathyManager empathy;
    public LifeManager lifeM;
    public Inventory inventario;
    public AimDirection aim;

    private Animator _animator;

    public Item[] guns;

    [SerializeField]
    float maxLife = 100;

    [SerializeField]
    float maxEmpathy = 100;
    public Camera _cam;
    public GameObject canvas;
    public float speed;

    public float lifeRef;
    public float empathyRef;
    public int indexGun;
    void Start()
    {
        Time.timeScale = 1.0f;
        _animator = GetComponent<Animator>();
        Rigidbody _rb = GetComponent<Rigidbody>();
        movement = new Movement(_rb, speed, _cam, transform);
        pause = new Pause();
        lifeM.initialize(this);
        
        controller = new Controller(movement, pause, canvas, empathy, _animator, speed, inventario);
        lifeM.maxLife = maxLife;
        empathy.maxEmpathy = maxEmpathy;
    }

    void Update()
    {
        aim.ForwardShooting(_cam);
        controller.Artificialupdate();
        empathy.RestEmpathy();

        lifeRef = lifeM.Life;
        empathyRef = empathy.Empathy;
        indexGun = inventario.indexRef;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IDialogable x = other.GetComponent<IDialogable>();
        if (x != null)
        {
            controller.dialogo = other.GetComponent<NPCScript>();
            controller.action = controller.ArtificialOnTrigger;
        }
        ICollectible y = other.GetComponent<ICollectible>();
        if (y != null)
        {
            other.GetComponent<ICollectible>().Plus();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IDialogable x = other.GetComponent<IDialogable>();
        if (x != null)
        {
            controller.action = controller.ArtificialExit;
        }



    }

}
