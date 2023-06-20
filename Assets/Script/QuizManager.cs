using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons;
    public TMP_Text timerText;
    public TMP_Text livesText;
    public GameObject endGamePanel;
    public GameObject quizFinishedPanel;
    public GameObject wrongPanel;
    public Image endGameImage;
    public Sprite allWrongImage;
    public Sprite allCorrectImage;
    public Sprite someCorrectImage;
    public Button restartButton;
    public Button sceneButton;

    private List<Question> questions;
    private Question currentQuestion;
    private int remainingLives;
    private float remainingTime;
    private bool waitingForAnswer;
    private bool quizFinished;

    private int correctAnswersCount;

    private void Start()
    {
        // Load and randomize questions
        LoadQuestions();
        quizFinishedPanel.SetActive(false);
        endGamePanel.SetActive(false);

        // Set initial timer and lives values
        remainingTime = 25f;
        remainingLives = 3;

        livesText.text = "Lives: " + remainingLives.ToString();

        // Start the quiz
        LoadNextQuestion();
    }

    private void LoadQuestions()
    {
        // Create a list of questions
        questions = new List<Question>();

        // Question 1
        Question q1 = new Question();
        q1.questionText = "Are you waiting for your the bus?";
        q1.answerOptions = new string[] { "No", "Yes"};
        q1.correctAnswerIndex = 1;
        questions.Add(q1);

        // Question 2
        Question q2 = new Question();
        q2.questionText = "Do you want this candy?";
        q2.answerOptions = new string[] { "No", "Yes"};
        q2.correctAnswerIndex = 0;
        questions.Add(q2);

        // Question 3
        Question q3 = new Question();
        q3.questionText = "Do you want me to send you home?";
        q3.answerOptions = new string[] { "No", "Yes" };
        q3.correctAnswerIndex = 0;
        questions.Add(q3);

        // Question 4
        Question q4 = new Question();
        q4.questionText = "Come follow me i would bring you to the playground?";
        q4.answerOptions = new string[] { "No", "Yes"};
        q4.correctAnswerIndex = 0;
        questions.Add(q4);
    }

    private void RandomizeQuestions()
    {
        // Shuffle the questions list to randomize the order
        questions.Shuffle();
    }

    private void DisplayQuestion(Question question)
    {
        // Set the question text
        questionText.text = question.questionText;

        // Assign the answer options to the buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = question.answerOptions[i];

            // Attach an onclick event to each button to check the answer
            int buttonIndex = i; // Required to avoid closure issues
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex));
        }
    }

    private void CheckAnswer(int selectedAnswerIndex)
    {
        if (waitingForAnswer || quizFinished)
        {
            return; // Ignore button clicks while waiting for the answer or if the quiz has finished
        }

        waitingForAnswer = true;

        if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
        {
            // Correct answer
            Debug.Log("Correct answer!");
            correctAnswersCount++;
            LoadNextQuestion();
        }
        else
        {
            // Wrong answer
            Debug.Log("Wrong answer!");
            remainingLives--;
            wrongPanel.SetActive(true);
            StartCoroutine(WrongAns());
            livesText.text = "Lives: " + remainingLives.ToString();

            if (remainingLives <= 0)
            {
                // Game over
                EndGame();
            }
            else
            {
                waitingForAnswer = false; // Allow the player to try again
            }
        }
    }

    private void LoadNextQuestion()
    {
        // Remove the onclick events from the answer buttons
        foreach (Button button in answerButtons)
        {
            button.onClick.RemoveAllListeners();
        }

        // Load the next question or end the quiz if no more questions remain
        if (questions.Count > 0)
        {
            currentQuestion = questions[0];
            questions.RemoveAt(0);
            DisplayQuestion(currentQuestion);

            // Reset the timer
            remainingTime = 25f;
            waitingForAnswer = false;
        }
        else
        {
            // Quiz finished
            QuizFinished();
        }
    }

    private void EndGame()
    {
        endGamePanel.SetActive(true);
        endGameImage.sprite = allWrongImage;

        // Attach restart button click event
        restartButton.onClick.AddListener(RestartGame);
    }

    private void QuizFinished()
    {
        quizFinished = true;
        quizFinishedPanel.SetActive(true);

        if (correctAnswersCount == answerButtons.Length)
        {
            endGameImage.sprite = allCorrectImage;
        }
        else
        {
            endGameImage.sprite = someCorrectImage;
        }

        // Attach scene button click event
        sceneButton.onClick.AddListener(OpenDifferentScene);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OpenDifferentScene()
    {
        SceneManager.LoadScene("Airlock");
    }

    private void Update()
    {
        if (waitingForAnswer || quizFinished)
        {
            return; // Don't update the timer while waiting for the answer or if the quiz has finished
        }

        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = Mathf.CeilToInt(remainingTime).ToString();

            if (remainingTime <= 0f)
            {
                // Time's up
                Debug.Log("Time's up!");

                if (remainingLives <= 0)
                {
                    // Game over
                    Debug.Log("Game over!");
                    EndGame();
                }

                EndGame();
            }
        }
    }

    
    private IEnumerator WrongAns(){
        yield return new WaitForSeconds(1f);
        wrongPanel.SetActive(false);
    }
}

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answerOptions;
    public int correctAnswerIndex;
}

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
