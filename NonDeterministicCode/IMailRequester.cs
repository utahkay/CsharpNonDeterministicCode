using System.Collections.Generic;

namespace NonDeterministicCode
{
    public interface IMailRequester
    {
        void Request(object template, string values, string recipient);
    }
}