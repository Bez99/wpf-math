using WpfMath.Boxes;

namespace WpfMath.Atoms
{
    /// <summary>
    /// Represents a matrix bounded by left and right parenthesis.
    /// </summary>
    internal class PmatrixAtom : Atom
    {
        public PmatrixAtom(SourceSpan source,Atom atom, TexAtomType type = TexAtomType.Ordinary) : base(source, type)
        {
            this.BaseAtom = atom;
        }

        public Atom BaseAtom { get; private set; }

        protected override Box CreateBoxCore(TexEnvironment environment)
        {
            var resultBox = new HorizontalBox();
            var innermatrix = this.BaseAtom == null ? StrutBox.Empty : this.BaseAtom.CreateBox(environment);
            var heightdiff = innermatrix.Depth - innermatrix.Height;

            var leftparen = DelimiterFactory.CreateBox("lbrack", innermatrix.TotalHeight, environment);
            leftparen.Shift = -innermatrix.Height + heightdiff;

            var rightparen = DelimiterFactory.CreateBox("rbrack", innermatrix.TotalHeight, environment);
            rightparen.Shift = -innermatrix.Height + heightdiff;

            innermatrix.Shift =  - (environment.MathFont.GetAxisHeight(environment.Style)-heightdiff)/3;

            resultBox.Add(leftparen);
            resultBox.Add(innermatrix);
            resultBox.Add(rightparen);

            return resultBox;
        }
    }
}
