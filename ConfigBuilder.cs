using System;
using System.Collections.Generic;

namespace myFluent
{
    public class ConfigBuilder
    {
        public static Dictionary<String, String> _values = new Dictionary<String, String>();

        public Config Outconfig { get; set; }

        public void configBuilder()
        {
            ConfigBuilder cb = new ConfigBuilder();
        }

        public ConfigBuilder WithFoo(ConfigBuilder cb, String foo)
        {
            _values["Foo"] = foo;
            //cb.foo = _values["Foo"];
            //return ConfigBuilder();
            return cb;
        }

        public ConfigBuilder WithSub(ConfigBuilder cb, String subfoo,String subbar)
        {
            _values["subFoo"] = subfoo;
            _values["subBar"] = subbar;
            //cb.foo = _values["Foo"];
            //return ConfigBuilder();
            return cb;
        }


        public Config Build(ConfigBuilder cb)
        {         
            var config = cb.Outconfig;
            config.Foo = _values["Foo"];
            config.SubConfig.Foo = _values["subFoo"];
            config.SubConfig.Bar = _values["subBar"];
            return config;
        }
    }

    

}

