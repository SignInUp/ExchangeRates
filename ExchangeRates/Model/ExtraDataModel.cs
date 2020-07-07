using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Model
{
    public struct ExtraDataModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public ExtraDataModel(string id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
