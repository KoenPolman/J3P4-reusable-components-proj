using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private string[] tutorialText;
    private TMP_Text field;
    private int currentStep = 0;
    private bool[] stepCompleted;

    void Start()
    {
        field = GetComponent<TMP_Text>();
        stepCompleted = new bool[tutorialText.Length];
        ShowCurrentStep();
    }

    void Update()
    {
        switch (currentStep)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
                    Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    CompleteStep();
                }
                break;

            case 1:
                if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.1f)
                {
                    CompleteStep();
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    CompleteStep();
                }
                break;
        }
    }

    void CompleteStep()
    {
        stepCompleted[currentStep] = true;
        currentStep++;
        if (currentStep < tutorialText.Length)
        {
            ShowCurrentStep();
        }
        else
        {
            field.text = "";
        }
    }

    void ShowCurrentStep()
    {
        field.text = tutorialText[currentStep];
    }
}
