using System;                   // ← DENNE LINJE ER VIGTIG!
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Kopi_af_Uge_5_RPSSL;

public partial class MainWindow : Window
{
    private enum Shape
    {
        Rock,
        Paper,
        Scissors,
        Spock,
        Lizard
    }

    private enum RoundResult
    {
        Tie,
        Player,
        Agent
    }

    private Random r = new Random();
    private int playerScore = 0;
    private int agentScore = 0;

    private int winningScore = 3;

    public MainWindow()
    {
        InitializeComponent();
        ScoreText.Text = "Score: 0 - 0";
    }

    private void Rock_Click(object? sender, RoutedEventArgs e)
    {
        PlayRound(Shape.Rock);
    }

    private void Paper_Click(object? sender, RoutedEventArgs e)
    {
        PlayRound(Shape.Paper);
    }

    private void Scissors_Click(object? sender, RoutedEventArgs e)
    {
        PlayRound(Shape.Scissors);
    }

    private void Spock_Click(object? sender, RoutedEventArgs e)
    {
        PlayRound(Shape.Spock);
    }

    private void Lizard_Click(object? sender, RoutedEventArgs e)
    {
        PlayRound(Shape.Lizard);
    }

    private void PlayRound(Shape player)
    {
        var agent = (Shape)r.Next(0, 5);

        PlayerText.Text = $"Player: {player}";
        AgentText.Text = $"Agent: {agent}";

        var result = Resolve(player, agent);

        if (result == RoundResult.Tie)
        {
            ResultText.Text = "Result: uafgjort";
        }
        else if (result == RoundResult.Player)
        {
            playerScore++;
            ResultText.Text = "Result: du vandt";
        }
        else
        {
            agentScore++;
            ResultText.Text = "Result: agenten vandt";
        }

        ScoreText.Text = $"Score: {playerScore} - {agentScore}";

        if (playerScore == winningScore || agentScore == winningScore)
        {
            if (playerScore == winningScore)
                ResultText.Text = "Player vandt spillet!";
            else
                ResultText.Text = "Agent vandt spillet!";

            // reset
            playerScore = 0;
            agentScore = 0;
            ScoreText.Text = "Score: 0 - 0";
        }
    }

    private RoundResult Resolve(Shape p1, Shape p2)
    {
        int diff = ((int)p2 - (int)p1 + 5) % 5;

        if (diff == 0)
            return RoundResult.Tie;

        if (diff == 1 || diff == 2)
            return RoundResult.Agent;

        return RoundResult.Player;
    }
}
