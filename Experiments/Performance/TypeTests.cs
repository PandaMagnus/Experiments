using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Performance
{
    public class TypeTests : TestBase
    {
        [Fact]
        public void CheckBool()
        {
            IterateOverAction(() =>
            {
                bool test = true;
                if (test is not true)
                {
                    throw new Exception();
                }
            });
        }

        [Fact]
        public void CheckType()
        {
            IterateOverAction(() =>
            {
                if (this.GetType() != typeof(CollectionTests))
                {
                    throw new Exception();
                }
            });
        }
    }
}
