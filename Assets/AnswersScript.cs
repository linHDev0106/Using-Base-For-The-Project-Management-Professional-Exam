using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswersScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public Color startColor;
    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }
    public void Answer()
    {
        StartCoroutine(SomeCoroutine());
    }

    private IEnumerator SomeCoroutine()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            yield return new WaitForSeconds(0.1f);
            quizManager.correct();
            GetComponent<Image>().color = startColor;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            yield return new WaitForSeconds(0.1f);
            quizManager.wrong();
            GetComponent<Image>().color = startColor;
        }
    }
}
