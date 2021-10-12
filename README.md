 # WEB API - TO DO 

Tecnologias utilizadas :

* .NET CORE 5.0
* Fluent Validation
* Entity Framework Core
* Entity Framework Design
* Entity Framework Sqlite
* Swagger

# INSTRUÇÃO DE USO:

 * Clonar o repositorio para seu local de desenvolvimento.
 * Rodar o comando => dotnet build , para instalar as referencias necessarias do projeto , so assim o projeto rodará sem erros.
 * Instalar o dotnet tools em seu ambiente via console comando => dotnet tool install --global dotnet-ef
 * Criar a migration do sistema como segue comando => dotnet ef migrations add InitialMigration
 * apos isto incluir o comando para gerar o db local que o sistema se utilizara => dotnet ef database update
 
 
Feito todos os procedimentos , o sistema estara pronto para uso , rodar com o comando => dotnet run / dotnet watch run
