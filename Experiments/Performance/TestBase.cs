using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    public class TestBase
    {
        private readonly long _Iterations = 1000000;
        private readonly Random _Rand = new();

        protected void IterateOverAction(Action action)
        {
            for (int i = 0; i < _Iterations; i++)
            {
                action();
            }
        }

        protected void IterateOverAction(Action<int> action)
        {
            for (int i = 0; i < _Iterations; i++)
            {
                int r = _Rand.Next(0, 10);
                action(r);
            }
        }
    }
}
