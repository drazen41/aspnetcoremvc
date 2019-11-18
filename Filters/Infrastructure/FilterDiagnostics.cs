using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public interface IFilterDiagnnostics
    {
        IEnumerable<string> Messages { get; }
        void AddMessage(string message);
    }
    public class FilterDiagnostics : IFilterDiagnnostics
    {
        private List<string> messages = new List<string>();
        public IEnumerable<string> Messages => messages;

        public void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
}
