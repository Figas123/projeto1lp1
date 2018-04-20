namespace Simplexity
{
    public class Board
    {
        private State[,] state;
        public State NextTurn { get; private set; }

        public Board()
        {
            state = new State[7, 7];
            NextTurn = State.player1;
        }

        public State GetState(Position position)
        {
            return state[position.Row, position.Column];
        }

        public bool SetState(Position position, State newState)
        {
            if (newState != NextTurn) return false;
            if (state[position.Row, position.Column] != State.Undecided) return false;

            state[position.Row, position.Column] = newState;
            SwitchNextTurn();
            return true;
        }
        
        private void SwitchNextTurn()
        {
            if (NextTurn == State.player1) NextTurn = State.player2;
            else NextTurn = State.player1;
        }
    }
}