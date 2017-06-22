namespace myFluent
{
	public sealed class Config
	{
		public string Foo { get; set; }

		public SubConfig SubConfig { get; set; }

        public static Config Default()
        {
            Config config = new Config();
            config.Foo = "";
            config.SubConfig = new SubConfig()
            {
                Foo = "",
                Bar = ""
            };
                
            return config;
        }


        

    }
}