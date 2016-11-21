using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class RayCastTree : MonoBehaviour {

    int rayLength = 10;

    private TreeController treeController;

    private PlayerController playerAnim;

    void Update()
    {
		TreeFall ();
    }

	public void TreeFall(){
		RaycastHit hit = new RaycastHit();
		Vector3 forward = transform.TransformDirection(Vector3.forward);

		if(Physics.Raycast(transform.position, forward, hit.distance, rayLength))
		{
			if (hit.collider.gameObject.tag.Equals("Tree"))
			{
				treeController = GameObject.Find(hit.collider.gameObject.name).GetComponent<TreeController>();
				playerAnim = GameObject.Find("FPSArms_Axe@Idle").GetComponent<PlayerController>();

				if (Input.GetButtonDown("Fire1") && playerAnim.CanSwing == true)
				{
					treeController.TreeHealth -= 1;
				}
			}
		}
	}
}
