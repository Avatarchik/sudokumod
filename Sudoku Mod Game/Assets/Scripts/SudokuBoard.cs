using UnityEngine;
using System.Collections;

public class SudokuBoard : MonoBehaviour {

	public enum Direction : byte { NONE, UP, DOWN, LEFT, RIGHT };

	private class Tile {
		public bool locked;
		public int digit;		
		public Direction direction;
		public bool hasMoved; // used while updating the board
		public Tile(){
			this.locked = false;
			this.digit = 0;
			this.direction = Direction.NONE;
		}
	}

	private Tile[,] board;
	public int size = 5;

	// Use this for initialization
	void Start () {
		board = new Tile[size, size];
		for (int r = 0; r < size; r++)
		{
			for (int c = 0; c < size; c++)
			{
				board[r, c] = new Tile();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void MoveTiles() {

		// mark all tiles that need to move
		for (int i = 0; i < size; i++) 
		{
			for (int j = 0; j < size; j++)
			{			
				if(board[i, j].digit > 0 && board[i, j].direction != Direction.NONE)
				{
					board[i, j].hasMoved = false;
				}
				else
				{
					board[i, j].hasMoved = true;
				}
			}
		}

		bool changed;
		do 
		{
			changed = false;
			for (int r = 0; r < size; r++)
			{
				for (int c = 0; c < size; c++)
				{
					Tile tile = board[r, c];
					// if the tile hasn't moved yet and wants to
					if (!tile.hasMoved)
					{	
						int rdst = r + (tile.direction == Direction.UP ? -1 : (tile.direction == Direction.DOWN ? 1 : 0));
						int cdst = c + (tile.direction == Direction.LEFT ? -1 : (tile.direction == Direction.RIGHT ? 1 : 0));

						// move it if its destination is empty
						if (board[rdst, cdst].digit == 0)
						{
							// move the tile to its destination
							board[rdst, cdst].digit = tile.digit;
							board[rdst, cdst].direction = tile.direction;
							board[rdst, cdst].locked = tile.locked;
							// mark it as fixed
							board[rdst, cdst].hasMoved = true;
							// clear its old location so another tile can move there
							board[r, c].digit = 0;
							board[r, c].hasMoved = true;
							changed = true; // iterate until all dependencies have resolved
						}
					}
				}
			}
		} while (changed);
	}

	public void SetDirection(int r, int c, Direction d)
	{
		board[r, c].direction = d;
	}

	public void SlideDownAll()
	{
		for (int c = 1; c < size - 1; c++)
		{
			board[0, c].direction = Direction.DOWN;
		}
	}
}
