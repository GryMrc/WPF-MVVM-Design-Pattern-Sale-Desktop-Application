using System;
using System.Collections.Generic;
using System.Text;

namespace OverPay.Model.Response
{
    public class JwtResponse<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int Total { get; set; }

        public string AggregateResults { get; set; }

        public string Errors { get; set; }
    }
}
