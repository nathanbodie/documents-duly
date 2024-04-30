using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;
    int index = -1;
    bool rotate = false;

    private void Start()
    {
        initialState();
    }

    public void initialState()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].transform.rotation = Quaternion.identity;
        }
        pages[0].SetAsLastSibling();
        backButton.SetActive(false);
    }

    public void rotateForward()
    {
        if (rotate) { return; }
        index++;
        
        // Needs to rotate 180 in the y direction to flip.
        float angle = 180; 
        forwardButtonActions();
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));

    }

    public void forwardButtonActions()
    {
        if (!(backButton.activeInHierarchy))
        {

            // Every time the page turns forward, back button activates.
            backButton.SetActive(true);
        }
        if (index == (pages.Count - 1))
        {

            // If it's on the last page, then forward button is off.
            forwardButton.SetActive(false);
        }
    }

    public void rotateBack()
    {
        if (rotate) { return; }

        // To rotate page back, set rotate 0 in y direction.
        float angle = 0; 
        pages[index].SetAsLastSibling();
        backButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    public void backButtonActions()
    {
        if (!(forwardButton.activeInHierarchy))
        {

            // Ever time page is turned back, forward button should be active.
            forwardButton.SetActive(true); 
        }
        if ((index - 1) == -1)
        {

            // If page is first, then turn back button off.
            backButton.SetActive(false);
        }
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;

            // Make smooth turn.
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value); 

            // Calculate angle between the given angle of rotation and current angle of rotation.
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation); 
            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;

            }
            yield return null;

        }
    }



}