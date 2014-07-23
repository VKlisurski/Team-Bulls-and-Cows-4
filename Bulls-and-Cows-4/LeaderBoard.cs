namespace BullsAndCowsGame
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of items containing information about the best scoring players.
    /// </summary>
    /// <typeparam name="T">The type of elements of the leaderboard.</typeparam>
    public class LeaderBoard<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable<T>
    {
        private const int DefaultNumberOfItems = 5;
        private readonly T[] data;
        private int maxNumberOfItems;
        private int position = -1;
        private int count;

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.LeaderBoard class.
        /// </summary>
        public LeaderBoard()
            : this(LeaderBoard<T>.DefaultNumberOfItems)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BullsAndCowsGame.LeaderBoard class.
        /// </summary>
        public LeaderBoard(int maxCountOfStoredData)
        {
            this.MaxNumberOfItems = maxCountOfStoredData;
            this.data = new T[this.maxNumberOfItems];
            this.Count = 0;
        }

        /// <summary>
        /// Gets the number of items in the LeaderBoard<T>.
        /// </summary>
        public int Count
        {
            get 
            { 
                return this.count; 
            }

            private set
            {
                this.count = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of items allowed in the leaderboard.
        /// </summary>
        public int MaxNumberOfItems
        {
            get
            {
                return this.maxNumberOfItems;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("The maximum number of items in the Leader Board must be positive");
                }

                this.maxNumberOfItems = value;
            }
        }

        /// <summary>
        /// Gets the element at the current position of the enumerator.
        /// </summary>
        public T Current
        {
            get
            {
                return this.data[this.position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.data[this.position];
            }
        }

        /// <summary>
        /// Adds an item to the LeaderBoard<T>.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void Add(T item)
        {
            // If this is the first item to be added
            if (this.Count == 0)
            {
                this.data[0] = item;
                this.Count++;
                return;
            }

            if (item.CompareTo(this.data[this.Count - 1]) >= 0)
            {
                int pointer = 0;
                while (item.CompareTo(this.data[pointer]) < 0)
                {
                    pointer++;
                }

                for (int i = this.MaxNumberOfItems - 1; i > pointer; i--)
                {
                    this.data[i] = this.data[i - 1];
                }

                this.data[pointer] = item;
                if (this.Count < this.MaxNumberOfItems)
                {
                    this.Count++;
                }
            }
            else
            {
                for (int i = 0; i < this.MaxNumberOfItems; i++)
                {
                    if (this.data[i] == null)
                    {
                        this.data[i] = item;
                        this.Count++;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the LeaderBoard<T>.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the LeaderBoard<T>.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        /// <summary>
        /// Releases all resources used by the LeaderBoard<T>.Enumerator.
        /// </summary>
        public void Dispose()
        {
            this.Reset();
        }

        /// <summary>
        /// Advances the enumerator to the next element of the LeaderBoard<T>.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (this.position < this.Count - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Resets the leaderboard.
        /// </summary>
        public void Reset()
        {
            this.position = -1;
        }
    }
}