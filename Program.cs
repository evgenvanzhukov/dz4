using System;

namespace myFluent
{
    class Program
    {
        //to-do: реализовать настройку конфига всеми известными методами

        static void Main(string[] args)
        {
            //как все (1)
            var config = new Config
            {
                Foo = "foo",
                SubConfig = new SubConfig
                {
                    Foo = "sub-foo",
                    Bar = "sub-bar",
                }
            };
            var foo = new Foo(config);


            //метод расширения класса (2)
            var extConfig = Config.Default().WithFoo("foo-ext").WithSub("sub-foo-ext", "sub-bar-ext");
            var extFoo = new Foo(extConfig);


            //передачей лямбды нового экземпляра класса конфиг (3)
            var lambdaconfig = Method(__config => {
                __config.Foo = "foo-lambda";
                __config.SubConfig.Foo = "sub-foo-lambda";
                __config.SubConfig.Bar = "sub-bar-labmda";
            });
            var lambdaFoo = new Foo(lambdaconfig);


            //создание класса Билдер (4)
            ConfigBuilder builder = new ConfigBuilder();
            builder = builder.WithFoo(builder,"foo-builder").WithSub(builder,"sub-foo-builder","sub-bar-builder");
            var bconfig = builder.Build(builder);
            var bfoo = new Foo(bconfig);


        }

        public static Config Method(Action<Config> action)
        {
            var config = new Config();
            action(config);
            return config;
        }
    }

    public static class Extentions
    {
        public static Config WithFoo(this Config config, string foo)
        {
            config.Foo = foo;
            return config;
        }
        public static Config WithSub(this Config config, string subfoo, string subbar)
        {
            config.SubConfig.Foo = subfoo;
            config.SubConfig.Bar = subbar;
            return config;
        }
    }

    

}

