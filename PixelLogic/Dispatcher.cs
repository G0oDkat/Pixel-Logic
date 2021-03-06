﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PixelLogic
{
    using System.Collections.Concurrent;
    using System.ComponentModel;

    interface IDispatcher
    {
        void Invoke(Action action);
    }

    class Dispatcher : IDispatcher
    {
        public static IDispatcher Current;

        private readonly ConcurrentQueue<Action> pending;

        public Dispatcher()
        {
            pending = new ConcurrentQueue<Action>();
        }

        public void Invoke(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            pending.Enqueue(action);
        }

        public void InvokePending()
        {
            while (pending.TryDequeue(out Action action))
            {
                action.Invoke();
            }
        }
    }
}
