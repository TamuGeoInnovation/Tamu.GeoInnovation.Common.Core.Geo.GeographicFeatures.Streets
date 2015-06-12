namespace USC.GISResearchLab.Common.Census.FIPSAttributes
{
    public class FIPSAttribute
    {

        #region Properties
        private string _FIPSCode;
        public string FIPSCode
        {
            get { return _FIPSCode; }
            set { _FIPSCode = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _NameSoundex;
        public string NameSoundex
        {
            get { return _NameSoundex; }
            set { _NameSoundex = value; }
        }

        private string _NameSoundexDM;
        public string NameSoundexDM
        {
            get { return _NameSoundexDM; }
            set { _NameSoundexDM = value; }
        }

        #endregion

        public FIPSAttribute()
        {
            FIPSCode = "";
            Name = "";
            NameSoundex = "";
            NameSoundexDM = "";
        }
    }
}
