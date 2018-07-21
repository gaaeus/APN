using System;

namespace APN.Models.Country
{
    public class Country
    {
        UInt64 id { get; set; }
        string Name { get; set; }
        string Alpha2Code { get; set; }
        string Alpha3Code { get; set; }
    }
}
