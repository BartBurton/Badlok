using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Direction of moving of any Game Objects
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// To move ToRight is moving objects in positive side
        /// </summary>
        ToRight = 1,
        /// <summary>
        /// To move ToLeft is moving objects in negative side
        /// </summary>
        ToLeft = -1
    }


    public class ReversibleDirection<T, TResult>
    {
        public Func<T, TResult> Action { get; private set; }


        private Func<T, TResult> _toLeft;
        public Func<T, TResult> ToLeft 
        { 
            private get => _toLeft;
            set
            {
                _toLeft = value;
                if (Direction == Direction.ToLeft) { Action = ToLeft; }
            }
        }

        private Func<T, TResult> _toRight;
        public Func<T, TResult> ToRight
        {
            private get => _toRight;
            set
            {
                _toRight = value;
                if (Direction == Direction.ToRight) { Action = ToRight; }
            }
        }

        private Direction _direction;
        public Direction Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                Action = (_direction != Direction.ToRight) ? ToLeft : ToRight;
            }
        }


        public ReversibleDirection(Direction direction, Func<T, TResult> toLeft, Func<T, TResult> toRight)
        {
            ToLeft = toLeft;
            ToRight = toRight;
            Direction = direction;
        }
    }
}
