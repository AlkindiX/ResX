using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResxEditor
{
    public class FindEventArg
    {
        public string FindText { get; private set; }
        public FindArgument Arguments { get; private set; }
        public FindPattren Pattren { get; private set; }

        public FindEventArg(string findtext, FindArgument arguments, FindPattren pattren)
        {
            if (findtext == null)
            {
                throw new ArgumentNullException("findtext");
            }
            if (Microsoft.VisualBasic.Information.IsNothing(arguments))
            {
                throw new ArgumentNullException("arguments");
            }
            if (Microsoft.VisualBasic.Information.IsNothing(pattren))
            {
                throw new ArgumentNullException("pattren");
            }
            FindText = findtext;
            Arguments = arguments;
            Pattren = pattren;
        }
    }
}