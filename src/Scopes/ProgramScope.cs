using System.Collections.Generic;
using System.IO;
using Lolc.Asts;
using Lolc.Scopes;

namespace Lolc.Scopes
{
    public class ProgramScope : AbstractScope
    {
        public GlobalScope GlobalScope { get; init; }

        public List<LocalScope> LocalScopes { get; } = new();

        public ProgramScope() : base(null)
        {
            GlobalScope = new GlobalScope(this);
        }

        public override void Emit(TextWriter outStream)
        {
            outStream.WriteLine(@"
.assembly extern mscorlib {}
.assembly MyLolCode {}
.class private auto ansi beforefieldinit Program
    extends [System.Private.CoreLib]System.Object
{");

            outStream.WriteLine(@"
.method public hidebysig specialname rtspecialname 
    instance void .ctor () cil managed 
{
    .maxstack 8

    ldarg.0
    call instance void [System.Private.CoreLib]System.Object::.ctor()
    nop
    ret
} // end of method Program::.ctor
");

            GlobalScope.Emit(outStream);

            foreach (var scope in LocalScopes)
            {
                scope.Emit(outStream);
            }

            outStream.WriteLine(@"
} // end of class
");
        }
    }
}