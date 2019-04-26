namespace ScroingAndBowlingApp
{
    public class Game
    {
        //Max rolls can happen in 10 frames will be 21
        readonly int[] rolls = new int[21];
        int currentRoll;

        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int Score()
        {
            int roll = 0;
            int score = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                //If strike roll, immedietly goes to next frame, second roll not considered
                if (IsStrikeRoll(roll))
                {
                    score += StrikeTotal(roll);
                    roll++;
                }
                //same as normal roll, score calclation is different
                else if (IsSpareRoll(roll))
                {
                    score += SpareTotal(roll);
                    roll += 2;
                }
                //Normal roll
                else
                {
                    score += TurnTotal(roll);
                    roll += 2;
                }
            }

            return score;
        }

        //Normal roll, frame score will be sum of two rolls
        private int TurnTotal(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        //Spare roll - score will be 10 + score of first roll of next frame
        private int SpareTotal(int roll)
        {
            return 10 + rolls[roll + 2];
        }

        //Strike roll - Score will be 10+ score of two rolls of next frame
        private int StrikeTotal(int roll)
        {
            return 10 + rolls[roll + 1] + rolls[roll + 2];
        }

        //If spare roll, sum of two rolls will be 10
        private bool IsSpareRoll(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        //If Strike roll, the same roll will score 10
        private bool IsStrikeRoll(int roll)
        {
            return rolls[roll] == 10;
        }
    }
}
