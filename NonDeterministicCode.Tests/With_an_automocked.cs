using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using StructureMap.AutoMocking;
using StructureMap.AutoMocking.Moq;

namespace NonDeterministicCode.Tests
{
    public abstract class With_an_automocked<T> where T : class
    {
        Establish context = () =>
        {
            autoMocker = new MoqAutoMocker<T>();
        };

        protected static T ClassUnderTest
        {
            get { return autoMocker.ClassUnderTest; }
        }

        protected static Mock<TMock> GetTestDouble<TMock>()
            where TMock : class
        {
            return Mock.Get(autoMocker.Get<TMock>());
        }

        protected static void Inject<TMock>(TMock target)
        {
            autoMocker.Inject(typeof(TMock), target);
        }

        static AutoMocker<T> autoMocker;
    }
}
