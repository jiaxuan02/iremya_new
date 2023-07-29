using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Lvl3_QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons;
    public TMP_Text timerText;
    public TMP_Text livesText;
    public GameObject endGamePanel;
    public GameObject quizFinishedPanel;
    public GameObject wrongPanel;
    public GameObject stars1;
    public GameObject stars2;
    public GameObject stars3;
    public Image endGameImage;
    public Sprite allWrongImage;
    public Sprite allCorrectImage;
    public Sprite someCorrectImage;
    public Button restartButton;
    public Button sceneButton;

    // Add the AudioSource component to the Lvl3_QuizManager GameObject in the Inspector
    public AudioSource audioSource;

    private List<Question> questions;
    private Question currentQuestion;
    private static int remainingLives;
    private float remainingTime;
    private bool waitingForAnswer;
    private bool quizFinished;

    private int correctAnswersCount;

    private void Start()
    {
        stars1.SetActive(false);
        stars2.SetActive(false);
        stars3.SetActive(false);
        Time.timeScale = 0;
        // Load and randomize questions
        LoadQuestions();
        quizFinishedPanel.SetActive(false);
        endGamePanel.SetActive(false);

        // Set initial timer and lives values
        remainingTime = 25f;
        remainingLives = 3;

        livesText.text = "Lives: " + remainingLives.ToString();

        // Set up the AudioSource component
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;

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
        q1.answerOptions = new string[] { "No", "Yes" };
        q1.correctAnswerIndex = 1;
        // Assign the voice line for Question 1
        q1.voiceLine = Resources.Load<AudioClip>("Liangfenzhong");
        questions.Add(q1);

        // Question 2
        Question q2 = new Question();
        q2.questionText = "Do you want to eat candy?";
        q2.answerOptions = new string[] { "No", "Yes" };
        q2.correctAnswerIndex = 0;
        // Assign the voice line for Question 2
        q2.voiceLine = Resources.Load<AudioClip>("Liangfenzhong");
        questions.Add(q2);

        // Question 3
        Question q3 = new Question();
        q3.questionText = "Do you want me to send you home?";
        q3.answerOptions = new string[] { "No", "Yes" };
        q3.correctAnswerIndex = 0;
        // Assign the voice line for Question 3
        q3.voiceLine = Resources.Load<AudioClip>("Liangfenzhong");
        questions.Add(q3);

        // Question 4
        Question q4 = new Question();
        q4.questionText = "Do you want to play my iPad? I left it in my car. We can go get it together.";
        q4.answerOptions = new string[] { "No", "Yes" };
        q4.correctAnswerIndex = 0;
        // Assign the voice line for Question 4
        q4.voiceLine = Resources.Load<AudioClip>("Liangfenzhong");
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

        // Play the voice line for the current question
        if (question.voiceLine != null)
        {
            // Stop any currently playing voice clip before playing the new one
            audioSource.Stop();
            // Play the new voice clip
            audioSource.PlayOneShot(question.voiceLine);
        }

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
        if (remainingLives == 3)
        {
            stars1.SetActive(true);
            stars2.SetActive(true);
            stars3.SetActive(true);
        }
        else if (remainingLives == 2)
        {
            stars1.SetActive(true);
            stars2.SetActive(true);
        }
        else if (remainingLives == 1)
        {
            stars1.SetActive(true);
        }
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

    private IEnumerator WrongAns()
    {
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
    public AudioClip voiceLine; // New field for the voice line
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
