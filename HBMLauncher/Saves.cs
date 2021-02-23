namespace HBMLauncher
{
    class Saves
    {
        private string name;
        private int cleop;
        private int csounds;
        private int radar;
        private string binderPath;
        private string macrosPath;
        private string ip;
        private string nickname;
        private string gtaPath;

        public Saves(string name, int cleop, int csounds, int radar, string binderPath, string macrosPath, string ip, string nickname, string gtaPath)
        {
            this.name = name;
            this.cleop = cleop;
            this.csounds = csounds;
            this.radar = radar;
            this.binderPath = binderPath;
            this.macrosPath = macrosPath;
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

        public int GetRadar()
        {
            return this.radar;
        }

        public string GetBinderPath()
        {
            return this.binderPath;
        }

        public string GetMacrosPath()
        {
            return this.macrosPath;
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

        public void SetCleop(int cleop)
        {
            this.cleop = cleop;
        }

        public void SetCsounds(int csounds)
        {
            this.csounds = csounds;
        }

        public void SetRadar(int radar)
        {
            this.radar = radar;
        }

        public void SetBinderPath(string binderPath)
        {
            this.binderPath = binderPath;
        }

        public void SetMacrosPath(string macrosPath)
        {
            this.macrosPath = macrosPath;
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