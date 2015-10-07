using System.Collections.Generic;

namespace NonDeterministicCode
{
    public interface IMailRequester
    {
        void Request(object template, Dictionary<string, string> values, string recipient);
    }
}