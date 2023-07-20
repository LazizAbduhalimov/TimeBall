using System;

public static class Bank
{
    public static int Coins { get; private set; }

    public static Action<object, int> OnCoinsValueChangedEvent;

    public static void AddCoins(object sender, int number)
    {
        if (number < 1)
            throw new ArgumentException("Number of coins should be positive");

        OnCoinsValueChangedEvent?.Invoke(sender, number);
        Coins += number;
    }

    public static void SpendCoins(object sender, int number)
    {
        if (number < 1)
            throw new ArgumentException("Number of coins should be positive");

        if (IsEnoughCoins(number))
            return;

        OnCoinsValueChangedEvent?.Invoke(sender, number);
        Coins -= number;
    }

    public static bool IsEnoughCoins(int number)
    {
        return Coins >= number;
    }
}
