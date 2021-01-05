namespace HBMLauncher
{
    class Saves
    {
        private string name;
        private int cleop;
        private int csounds;
        private string ip;
        private string nickname;
        private string gtaPath;

        public Saves()
        {

        }

        public Saves(string name, int cleop, int csounds, string ip, string nickname, string gtaPath)
        {
            this.name = name;
            this.cleop = cleop;
            this.csounds = csounds;
            this.ip = ip;
            this.nickname = nickname;
            this.gtaPath = gtaPath;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetCleop()
        {
            return this.cleop;
        }

        public int GetCsounds()
        {
            return this.csounds;
        }

        public string GetIp()
        {
            return this.ip;
        }

        public string GetNickname()
        {
            return this.nickname;
        }

        public string GetGtaPath()
        {
            return this.gtaPath;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetCleop(int cleop)
        {
            this.cleop = cleop;
        }

        public void SetCsounds(int csounds)
        {
            this.csounds = csounds;
        }

        public void SetIp(string ip)
        {
            this.ip = ip;
        }

        public void SetNickname(string nickname)
        {
            this.nickname = nickname;
        }

        public void SetGtaPath(string gtaPath)
        {
            this.gtaPath = gtaPath;
        }
    }
}
