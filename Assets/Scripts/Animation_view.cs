using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class Animation_view : MonoBehaviour {

	private Animator anim;
	public Vector2 scrollPosition = Vector2.zero; 
//	private AnimatorStateInfo currentState;		// 
//	private AnimatorStateInfo previousState;	// 
	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
//		currentState = anim.GetCurrentAnimatorStateInfo (0);
//		previousState = currentState;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{	
		if(GUI.Button(new Rect(10, 10, 130, 20), "Combo_01"))
			anim.SetBool ("Combo_01", true);
		if(GUI.Button(new Rect(10, 35, 130, 20), "Combo_02"))
			anim.SetBool ("Combo_02", true);
	}
}
