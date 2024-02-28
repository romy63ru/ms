
public class SolutionCoins
{
    public int Change(int amount, int[] coins)
    {

        var memo = new int[coins.Length, amount + 1];
        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = 0; j < amount + 1; j++)
            {
                memo[i, j] = -1;
            }
        }

        return findUniqueCombos(0, amount);

        int findUniqueCombos(int index, int balance)
        {
            if (balance < 0) return 0;
            if (balance == 0) return 1;

            if (memo[index, balance] != -1) return memo[index, balance];
            int total = 0;
            for (int i = index; i < coins.Length; i++)
            {
                total += findUniqueCombos(i, balance - coins[i]);
            }
            return memo[index, balance] = total;
        }
    }
}
