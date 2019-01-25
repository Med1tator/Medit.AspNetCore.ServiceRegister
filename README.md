# Medit.AspNetCore.ServiceRegister
AspNetCore项目动态注入

项目相对比较简单，通过读取Service的接口和实现的程序集以及类型的配置，使用IServiceCollection.Add()方法注入。
可用于替换Service，改变Service实现。
