namespace APLTools.Logic
{
    public class AddArtRange
    {
        #region Private Variables
        private int _min;
        private int _max;
        #endregion

        #region Class Constructors
        public AddArtRange(int min, int max)
        {
            _min = min;
            _max = max;
        }
        #endregion

        #region Public Functions
        public bool IsWithinRange(int refId)
        {
            bool inrange = false;

            if (refId >= Min && refId <= Max)
            {
                inrange = true;
            }

            return inrange;
        }
        #endregion

        #region Public Readonly Properties
        public int Min { get { return _min; } }
        public int Max { get { return _max; } }

        public string Foldername
        {
            get
            {
                return string.Format("{0}-{1}/",Min.ToString().PadLeft(5,'0'),Max.ToString().PadLeft(5,'0'));
            }
        }
        #endregion
    }
}
