using System;
using System.IO;
using System.Linq;
using Lolc.Asts;
using Lolc.Scopes;

namespace Lolc
{
    public class GlobalScope : AbstractScope
    {
        public override bool IsGlobal => true;

        public GlobalScope(AbstractScope parent) : base(parent)
        {
        }

        public override void Emit(TextWriter outStream)
        {
            outStream.WriteLine(@"
// Fields");

            foreach (var sym in Symbols)
            {
                outStream.WriteLine($"    .field private {sym.ValueType.ToCilType()} {sym.Identifier}");
            }

            outStream.WriteLine(@"
// Methods
.method private hidebysig static 
    void Main (
        string[] args
    ) cil managed 
{
    .entrypoint

    .maxstack 8

    nop
    newobj instance void Program::.ctor()
    call instance void Program::Main()
    nop
    ret
} // end of method Program::Main

.method private hidebysig 
    instance void Main () cil managed 
{");

            outStream.WriteLine(Body);

            outStream.WriteLine("    ret");
            outStream.WriteLine("}");
        }
    }
}