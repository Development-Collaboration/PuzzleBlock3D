using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameObjectsTransform : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 startRotation;
    private Vector3 startScale;

    private Vector3 newRotation;

    [SerializeField] private float rotationSpeed = 10f;

    private void Start()
    {

        startPosition = this.transform.position;
        startRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        startScale = this.transform.localScale;

    }


    public void RotateTransform(DIRECTION direction)
    {
        newRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        switch (direction)
        {
            case DIRECTION.UR:
                {

                    newRotation = new Vector3(transform.rotation.x,
                            transform.rotation.y, transform.rotation.z + 90f);

                }
                break;

            case DIRECTION.DR:
                {

                    newRotation = new Vector3(transform.rotation.x + 90f,
                            transform.rotation.y, transform.rotation.z);
                }

                break;

            case DIRECTION.DL:
                {

                    newRotation = new Vector3(transform.rotation.x,
                            transform.rotation.y, transform.rotation.z - 90f);

                }

                break;

            case DIRECTION.UL:
                {
                    newRotation = new Vector3(transform.rotation.x - 90f,
                        transform.rotation.y, transform.rotation.z);
                }
                break;


        }

        Quaternion targetRot = Quaternion.Euler(newRotation);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

    }
}
