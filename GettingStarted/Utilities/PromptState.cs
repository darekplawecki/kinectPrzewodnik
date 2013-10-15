using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przewodnik.Utilities
{
    public enum PromptState
    {
        /// <summary>
        /// Preconditions to show the prompt have not been met.
        /// </summary>
        Hidden,

        /// <summary>
        /// Prompt is being shown to user.
        /// </summary>
        Prompting,

        /// <summary>
        /// Prompt preconditions have been met, but prompt has been dismissed.
        /// </summary>
        Dismissed
    }
}
