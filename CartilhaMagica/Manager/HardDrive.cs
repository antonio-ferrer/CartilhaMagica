namespace CartilhaMagica.Manager
{
    public class HardDrive
    {
        public string Model
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string SerialNo
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Model + "\r\n" + Type + "\r\n" + SerialNo;
        }
    }
}
