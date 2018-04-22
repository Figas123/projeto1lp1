namespace Simplexity
{
    public class Board
    {
        private State[,] state;
        public State NextTurn { get; private set; }
        /// <summary>
        /// Defines the grid size.
        /// </summary>
        public Board()
        {
            state = new State[7, 7];
            NextTurn = State.player1;
        }
        /// <summary>
        /// Returns the value of the choosen position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public State GetState(Position position)
        {
            return state[position.Row, position.Column];
        }
        /// <summary>
        /// Places the shape on the choosen position.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        public bool SetState(Position position, State newState)
        {
            if (newState != NextTurn) return false;
            if (state[position.Row, position.Column] != State.Undecided) return false;

            state[position.Row, position.Column] = newState;
            SwitchNextTurn();
            return true;
        }
        /// <summary>
        /// Switches turns between the players.
        /// </summary>
        private void SwitchNextTurn()
        {
            if (NextTurn == State.player1) NextTurn = State.player2;
            else NextTurn = State.player1;
        }
    }
}