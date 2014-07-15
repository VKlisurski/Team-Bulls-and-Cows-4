namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;

    public class LeaderBoard<T> : IEnumerable<T>, IEnumerator<T> where T : IComparable<T>
    {
        private const int DefaultNumberOfItemsInLeaderBoard = 5;
        private int maxNumberOfItems;
        private readonly T[] data;
        private int position = -1;
        private int count;

        public LeaderBoard()
            : this(DefaultNumberOfItemsInLeaderBoard)
        {
        }

        public LeaderBoard(int maxCountOfStoredData)
        {
            this.MaxNumberOfItems = maxCountOfStoredData;
            this.data = new T[this.maxNumberOfItems];
            this.Count = 0;
        }

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

        public T Current
        {
            get
            {
                return this.data[this.position];
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                return this.data[this.position];
            }
        }

        public void Add(T item)
        {
            // If this is the first item to be added
            if (this.Count == 0)
            {
                this.data[0] = item;
                this.count++;
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

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }

        public void Dispose()
        {
            this.Reset();
        }

        public bool MoveNext()
        {
            if (this.position < this.Count - 1)
            {
                this.position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}
