using UnityEngine;

public class Movement : MonoBehaviour 
{
	CharacterController controller;

    public float Speed = 12f;
    
	public float gravity = -9.81f;
    
	Vector3 velocity;

    public Transform groundCheck;
    
	public float groundDistance =0.4f;
    
	public LayerMask groundMask;
    
	bool isGrounded;

	void Awake()
	{
		controller = GetComponent<CharacterController>();
	}
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
        float x = Input.GetAxis("Vertical");
        
		float z = Input.GetAxis("Horizontal");
        
        Vector3  move = transform.right * x + transform.forward * z;
        
        controller.Move(move * Speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;
        
		controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    	if(isGrounded && velocity.y < 0)
		{
        	velocity.y = -2f;
		}
	}
}