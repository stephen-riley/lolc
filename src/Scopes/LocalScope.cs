using System.IO;
using Lolc.Scopes;

namespace Lolc
{
    public class LocalScope : AbstractScope
    {
        public LocalScope(AbstractScope parent) : base(parent)
        {
        }

        public override void Emit(TextWriter outStream)
        {
            throw new System.NotImplementedException();
        }
    }
}