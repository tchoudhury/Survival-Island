using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

    private int treeHealth = 5;
	[SerializeField] private Transform logs;
	[SerializeField] private Transform coconut;
    private GameObject tree;
    private int speed = 8;
    private Rigidbody rigidBody;

    void Start()
    {
        tree = this.gameObject;
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
    }

    void Update()
    {
        if (treeHealth <= 0)
        {
            rigidBody.isKinematic = false;
            rigidBody.AddForce(transform.forward * speed);
            DestroyTree();
        }
    }

	IEnumerator DestroyTree()
    {
        yield return new WaitForSeconds(7);
        Destroy(tree);

        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
		Instantiate(logs, tree.transform.position + Vector3.zero + position, Quaternion.identity);
        Instantiate(logs, tree.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
        Instantiate(logs, tree.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);

		Instantiate(coconut, tree.transform.position + Vector3.zero + position, Quaternion.identity);
        Instantiate(coconut, tree.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
        Instantiate(coconut, tree.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);

    }

	public int TreeHealth{
		get{ return treeHealth;}
		set{ TreeHealth = value;}
	}

	public Transform Logs{
		get{ return logs;}
		set{ logs = value;}
	}

	public Transform Coconut{
		get{ return coconut;}
		set{ coconut = value;}
	}

	public GameObject Tree{
		get{ return tree;}
		set{ Tree = value;}
	}

}
